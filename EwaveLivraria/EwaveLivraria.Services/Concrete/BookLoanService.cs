using AutoMapper;
using EwaveLivraria.Data.Enums;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Model;
using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Concrete
{
    public class BookLoanService : IBookLoanService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookLoanRepository _bookLoanRepository;
        private readonly IBookInventoryRepository _bookInventoryRepository;
        private readonly IMapper _mapper;

        public BookLoanService(IBookLoanRepository bookLoanRepository, IUserRepository userRepository, IBookInventoryRepository bookInventoryRepository, IMapper mapper)
        {
            _bookLoanRepository = bookLoanRepository;
            _userRepository = userRepository;
            _bookInventoryRepository = bookInventoryRepository;
            _mapper = mapper;
        }

        //Permitir Reserva de Livros se:
        //Se Estoque de livro for > 0
        //Se livro não estiver descontinuado (inativo)
        //Se usuario nao estiver bloqueado
        //Se usuário não estiver dois empréstimos em progresso
        //Se data informada for menor que 30 dias
        //Se instituição nao estiver inativa
        public async Task<ReturnModel> BookReservation(BookLoanRequest request)
        {
            var (condition, errorMsg) = await CanUserLoanBook(request.UserId, request.BookId, request.LoanUntil);
            if (!condition)
                return new ReturnModel { Errors = errorMsg };

            var bookInventory = await _bookInventoryRepository.GetByBookId(request.BookId);
            bookInventory.Quantity -= 1;
            await _bookInventoryRepository.Update(bookInventory);

            var bookLoan = new BookLoan
            {
                BeginDate = DateTime.Now,
                EndDate = request.LoanUntil,
                BookId = request.BookId,
                UserId = request.UserId,
                LoanStatusId = (int) BookLoanStatus.BookReserved
            };
            var result = await _bookLoanRepository.Insert(bookLoan);

            return new ReturnModel { Data = _mapper.Map<BookLoanModel>(result)};
        }

        //Permitir empréstimo se:
        //Se Estoque de livro for > 0
        //Se livro não estiver descontinuado (inativo)
        //Se usuario nao estiver bloqueado
        //Se usuário não estiver dois empréstimos em progresso
        //Se data informada for menor que 30 dias
        //Se instituição nao estiver inativa
        public async Task<ReturnModel> CreateBookLoan(BookLoanRequest request)
        {
            var (condition, errorMsg) = await CanUserLoanBook(request.UserId,request.BookId,request.LoanUntil);
            if (!condition)
                return new ReturnModel { Errors= errorMsg };

            var bookReservation = await _bookLoanRepository.GetBookReservations(request.UserId, request.BookId);
            //Caso o usuário já tenha feito reserva do livro, atualizar o status do emprestimo
            if(bookReservation != null)
            {
                bookReservation.LoanStatusId = (int) BookLoanStatus.BookLoanInProgress;
                var result = await _bookLoanRepository.Update(bookReservation);
                return new ReturnModel { Data = _mapper.Map<BookLoanModel>(result) };
            }
            else
            {
                var bookInventory = await _bookInventoryRepository.GetByBookId(request.BookId);
                bookInventory.Quantity -= 1;
                await _bookInventoryRepository.Update(bookInventory);

                var bookLoan = _mapper.Map<BookLoan>(request);
                bookLoan.BeginDate = DateTime.Now;
                bookLoan.EndDate = request.LoanUntil;
                bookLoan.LoanStatusId = (int)BookLoanStatus.BookLoanInProgress;
                var result = await _bookLoanRepository.Insert(bookLoan);

                return new ReturnModel { Data = _mapper.Map<BookLoanModel>(result) };
            }
        }

        public async Task<ReturnModel> ReturnBook(int bookLoanId)
        {            
            var bookLoan = await _bookLoanRepository.GetById(bookLoanId);
            if (bookLoan == null)
                return new ReturnModel { Errors = "Empréstimo não encontrado" };
            if (bookLoan.LoanStatusId == (int) BookLoanStatus.BookReserved ||
                bookLoan.LoanStatusId == (int) BookLoanStatus.BookReturned)
                return new ReturnModel { Errors = "Empréstimo já encerrado ou ainda não iniciado." };

            //Atualizar o estoque após a devolução
            var bookInventory = await _bookInventoryRepository.GetByBookId(bookLoan.Book.Id);
            bookInventory.Quantity += 1;
            await _bookInventoryRepository.Update(bookInventory);

            //Bloquear o Usuário se passar da data de entrega do livro
            if (DateTime.Now > bookLoan.EndDate)
                bookLoan.User.IsActive = false;

            bookLoan.LoanStatusId = (int)BookLoanStatus.BookReturned;
            bookLoan.ReturnedDate = DateTime.Now;
            var result = await _bookLoanRepository.Update(bookLoan);

            return new ReturnModel { Data = _mapper.Map<BookLoanModel>(result) };
        }

        public async Task<ReturnModel> FilterBookLoans(string filter, int statusId)
        {
            var status = BookLoanStatus.BookLoanInProgress;
            switch (statusId)
            {
                case 1:
                    status = BookLoanStatus.BookReserved; 
                    break;
                case 2:
                    status = BookLoanStatus.BookLoanInProgress; 
                    break;
                case 3:
                    status = BookLoanStatus.BookReturnDelayed;
                    break;
                case 4:
                    status = BookLoanStatus.BookReturned;
                    break;
            }

            var bookLoans = await _bookLoanRepository.FilterBookLoan(filter, status);
            return new ReturnModel { Data = _mapper.Map<List<BookLoanModel>>(bookLoans)};
        }

        public async Task<ReturnModel> GetBookLoan(int id)
        {
            var bookLoan = await _bookLoanRepository.GetById(id);
            return new ReturnModel { Data = _mapper.Map<BookLoanModel>(bookLoan) };
        }
             
        private async Task<(bool condition,string errorMsg)> CanUserLoanBook(int userId, int bookId, DateTime loanUntil)
        {
            if (loanUntil > DateTime.Now.AddDays(30))
                return (false, "Data Informada deve ser menor que 30 dias");

            var user = await _userRepository.GetById(userId);
            if (!user.IsActive)
                return (false, "Usuário não está apto a fazer novo empréstimo");

            var bookLoans = await _bookLoanRepository.GetBookLoansNotFinishedByUser(userId);
            if (bookLoans.Count == 2)
                return (false, "Usuário já possui 2 empréstimos em andamento.");

            if (!user.Institution.IsActive)
                return (false, "Usuário deve estar associado a uma Instituição Ativa");

            return await HasBookAvailableAndActive(bookId);
        }

        private async Task<(bool condition, string errorMsg)> HasBookAvailableAndActive(int bookId)
        {
            var bookInventory = await _bookInventoryRepository.GetByBookId(bookId);
            if(bookInventory == null)
                return (false, "Livro não encontrado");

            if (bookInventory.Quantity == 0)
                return (false, "Livro não disponível no estoque");

            if (!bookInventory.Book.IsActive)
                return (false, "Livro está discontinuado");

            return (true, null);
        }
    }
}

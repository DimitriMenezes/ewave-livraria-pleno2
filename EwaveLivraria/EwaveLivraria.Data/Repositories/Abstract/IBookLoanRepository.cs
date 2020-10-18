using EwaveLivraria.Data.Enums;
using EwaveLivraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Abstract
{
    public interface IBookLoanRepository : IBaseRepository<BookLoan>
    {
        Task<List<BookLoan>> FilterBookLoan(string userCpf, string bookTitle,
            BookLoanStatus status = BookLoanStatus.BookLoanInProgress);

        //Task<List<BookLoan>> GetBookLoansByUser(int userId);
        Task<List<BookLoan>> GetBookLoansNotFinishedByUser(int userId);
        Task<BookLoan> GetBookReservations(int userId, int bookId);
    }
}

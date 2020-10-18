using EwaveLivraria.Data.Enums;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Context;
using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Concrete
{
    public class BookLoanRepository : BaseRepository<BookLoan>, IBookLoanRepository
    {
        public BookLoanRepository(ApplicationContext context) : base(context)
        {
        }

        public override IQueryable<BookLoan> Include()
        {
            return _dbSet
                .Include(i => i.Book)
                .Include(i => i.User);
        }

        public Task<List<BookLoan>> FilterBookLoan(string userCpf, string bookTitle, 
            BookLoanStatus status = BookLoanStatus.BookLoanInProgress)
        {
            var query = Include();
            if (!string.IsNullOrEmpty(userCpf))
                query = query.Where(i => i.User.Cpf == userCpf);
            if (!string.IsNullOrEmpty(bookTitle))
                query = query.Where(i => i.Book.Title.Contains(bookTitle));
            query = query.Where(i => i.LoanStatusId == (int) status);

            return query.ToListAsync();
        }

        public Task<List<BookLoan>> GetBookLoansNotFinishedByUser(int userId)
        {
            return Include().Where(i => i.UserId == userId && i.LoanStatusId != (int) BookLoanStatus.BookReturned)
                .ToListAsync();
        }

        public Task<BookLoan> GetBookReservations(int userId, int bookId)
        {
            return Include().FirstOrDefaultAsync(i => i.UserId == userId && i.BookId == bookId
                && i.LoanStatusId == (int)BookLoanStatus.BookReserved);
        }
    }
}

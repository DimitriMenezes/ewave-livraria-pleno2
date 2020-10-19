using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Abstract
{
    public interface IBookLoanService
    {
        Task<ReturnModel> BookReservation(BookLoanRequest request);
        Task<ReturnModel> CreateBookLoan(BookLoanRequest request);
        Task<ReturnModel> ReturnBook(int bookLoanId);        
        Task<ReturnModel> FilterBookLoans(string filter, int statusId);
        Task<ReturnModel> GetBookLoan(int id);
    }
}

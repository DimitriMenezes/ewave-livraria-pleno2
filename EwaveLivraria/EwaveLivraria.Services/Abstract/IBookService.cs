using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Abstract
{
    public interface  IBookService
    {
        Task<ReturnModel> CreateBook(BookRequest request);
        Task<ReturnModel> UpdateBook(BookRequest request);        
        Task<ReturnModel> DiscontinueBook(int id);
        Task<ReturnModel> GetBook(int id);
        Task<ReturnModel> GetBooks(BookSearchRequest request);
    }
}

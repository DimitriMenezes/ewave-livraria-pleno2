using AutoMapper;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Model;
using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.FluentValidator;
using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookInventoryRepository _bookInventoryRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IBookInventoryRepository bookInventoryRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookInventoryRepository = bookInventoryRepository;
            _mapper = mapper;
        }

        public async Task<ReturnModel> CreateBook(BookRequest request)
        {
            var bookValidator = new BookValidator().Validate(request);
            if (!bookValidator.IsValid)
                return new ReturnModel { Errors = bookValidator.Errors };

            var book = _mapper.Map<Book>(request);
            book.IsActive = true;
            book.RegisteredAt = DateTime.Now;

            var result = await _bookRepository.Insert(book);

            var bookInventory = new BookInventory
            {
                BookId = result.Id,
                Quantity = request.Quantity
            };

            await _bookInventoryRepository.Insert(bookInventory);

            var bookModel = _mapper.Map<BookModel>(book);
            bookModel.Quantity = request.Quantity;
            return new ReturnModel { Data = bookModel };
        }

        public async Task<ReturnModel> DiscontinueBook(int id)
        {
            var discontinueBook = true;
            var bookInventory = await UpdateBookInventory(id, 0, discontinueBook);
          
            var bookModel = _mapper.Map<BookModel>(bookInventory.Book);
            bookModel.Quantity = bookInventory.Quantity;
            return new ReturnModel { Data = bookModel };
        }

        public async Task<ReturnModel> GetBook(int id)
        {
            var bookInventory = await _bookInventoryRepository.GetByBookId(id);
            if(bookInventory == null)              
                return new ReturnModel { Errors = "Livro não encontrado" };

            var bookModel = _mapper.Map<BookModel>(bookInventory.Book);
            bookModel.Quantity = bookInventory.Quantity;
            return new ReturnModel { Data = bookModel };
        }

        public async Task<ReturnModel> GetBooks(BookSearchRequest request)
        {
            var bookList = await _bookRepository.GetWithFilter(request.Isbn, request.Author, request.Title, request.Genre);
                        
            return new ReturnModel { Data = _mapper.Map<List<BookModel>>(bookList) };
        }

        public async Task<ReturnModel> UpdateBook(BookRequest request)
        {
            var bookValidator = new BookValidator().Validate(request);
            if (!bookValidator.IsValid)
                return new ReturnModel { Errors = bookValidator.Errors };

            var book = await _bookRepository.GetByIsbn(request.Isbn);
            if (book == null)
                return new ReturnModel { Errors = "Livro não encontrado" };


            book = await UpdateEntity(book, request);

            var bookModel = _mapper.Map<BookModel>(book);
            bookModel.Quantity = request.Quantity;
            return new ReturnModel { Data = bookModel };
        }

        private async Task<Book> UpdateEntity(Book entity, BookRequest newEntity)
        {            
            await UpdateBookInventory(entity.Id, newEntity.Quantity);

            if (entity.Genre != newEntity.Genre)
                entity.Genre = newEntity.Genre;
            if (entity.Title != newEntity.Title)
                entity.Title = newEntity.Title;
            if (entity.CoverUrl != newEntity.CoverUrl)
                entity.CoverUrl = newEntity.CoverUrl;
            if (entity.Author != newEntity.Author)
                entity.Author = newEntity.Author;
            
            return await _bookRepository.Update(entity);
        }

        private async Task<BookInventory> UpdateBookInventory(int bookId, int quantity, bool discontinueBook = false)
        {
            var bookInventory = await _bookInventoryRepository.GetById(bookId);
            bookInventory.Quantity = quantity;
            if (discontinueBook)
                bookInventory.Book.IsActive = false;

            return await _bookInventoryRepository.Update(bookInventory);
        }
    }
}

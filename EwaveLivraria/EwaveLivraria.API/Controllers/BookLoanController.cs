using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.Model.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwaveLivraria.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class BookLoanController : ControllerBase
    {
        private readonly IBookLoanService _bookLoanService;

        public BookLoanController(IBookLoanService bookLoanService)
        {
            _bookLoanService = bookLoanService;
        }

        //Como Administrador
        //Quero Obter Listagem de todos os empréstimos
        //Com filtros: Usuário, Título do Livro, Status do Empréstimo
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAllBookLoans(BookLoanSearchRequest request)
        {

            var result = await _bookLoanService.FilterBookLoans(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Dado Que Sou Administrador
        //Quero Visualizar a situação de um empréstimo
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetBookLoan(int id)
        {
            var result = await _bookLoanService.GetBookLoan(id);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Como Administrador
        //Quero Cadastrar emprestimo de um Livro para Um Usuário
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> LoanBookToUser(BookLoanRequest request)
        {
            var result = await _bookLoanService.CreateBookLoan(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Como Administrador
        //Quero registrar devolução de livro
        [HttpPost]
        [Route("{id}/return")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> BookReturn(int id)
        {
            var result = await _bookLoanService.ReturnBook(id);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Como Usuário
        //Quero Reservar um Livro
        //Para depois pegar emprestado
        [HttpPost]
        [Route("reservation")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> BookReservation(BookLoanRequest request)
        {
            var result = await _bookLoanService.BookReservation(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }
    }
}

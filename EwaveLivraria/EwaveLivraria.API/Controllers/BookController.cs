using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.Model.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwaveLivraria.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class BookController : ControllerBase
    {        
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //Como Administrador
        //Quero Cadastrar um Novo Livro
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateBook(BookRequest request)
        {
            var result = await _bookService.CreateBook(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Como Administrador
        //Quero Atualizar informações (inclusive o estoque) de um livro 
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateBook(BookRequest request)
        {
            var result = await _bookService.UpdateBook(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Como Administrador
        //Quero discontinuar (inativar) um livro
        //E zerar o estoque
        [HttpPut]
        [Route("{id}/discontinue")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var result = await _bookService.DiscontinueBook(id);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Como Usuário e Administrador
        //Quero buscar livros por ISBN, Autor, Title, Genero
        [HttpGet]
        [Authorize(Roles = "Administrator, User")]
        public async Task<IActionResult> FilterBook(BookSearchRequest request)
        {
            var result = await _bookService.GetBooks(request);           
            return Ok(result.Data);
        }
    }
}

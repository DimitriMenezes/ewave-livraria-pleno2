using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwaveLivraria.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class BookLoanController : ControllerBase
    {
        //Como Administrador
        //Quero Obter Listagem de todos os empréstimos
        //Com filtros: Usuário, Título do Livro, Status do Empréstimo
        [HttpGet]
        [Route("testeadmsdfsdfs")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllBookLoans()
        {            
            return Ok();
        }

        //Dado Que Sou Administrador
        //Quero Visualizar a situação de um empréstimo
        [HttpGet]
        [Route("b")]
        public async Task<ActionResult> GetBookLoan(int id)
        {            
            return Ok();
        }

        //Como Administrador
        //Quero Cadastrar emprestimo de um Livro para Um Usuário
        [HttpPost]
        [Route("a")]
        public async Task<ActionResult> LoanBookToUser()
        {
            return Ok();
        }

        //Como Administrador
        //Quero registrar devolução de livro
        [HttpPost]
        [Route("return")]
        public async Task<ActionResult> BookReturn()
        {
            return Ok();
        }

        //Como Usuário
        //Quero Reservar um Livro
        //Para depois pegar emprestado
        [HttpPost]
        [Route("reservation")]
        public async Task<ActionResult> BookReservation()
        {
            return Ok();
        }    

    }
}

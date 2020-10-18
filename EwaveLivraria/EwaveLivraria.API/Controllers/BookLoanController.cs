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
        [HttpGet]
        [Route("testeadmsdfsdfs")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllBookLoans()
        {            
            return Ok();
        }

        //Como Administrador
        //Quero Obter Listagem de Empréstimos de um Determinado Usuário
        [HttpGet]
        [Route("{userId}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllBookLoansOfUser(int userId)
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
        //Quero Reservar um Livro para Um Usuário
        [HttpPost]
        [Route("a")]
        public async Task<ActionResult> LoanBookToUser()
        {
            return Ok();
        }


        //Como Administrador
        //Quero Obter Listagem de Usuários
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok();
        }

        //Como Usuário
        //Quero Reservar um Livro
        [HttpPost]
        [Route("reservation")]
        public async Task<ActionResult> BookReservation()
        {
            return Ok();
        }
    }
}

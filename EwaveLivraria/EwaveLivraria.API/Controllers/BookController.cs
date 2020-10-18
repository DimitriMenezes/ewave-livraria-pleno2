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
        //[Authorize(Roles="Administrator")]



        //Como Administrador
        //Quero Cadastrar um Novo Livro

        //Como Administrador
        //Quero Atualizar informações de Um Livro

        //Como Administrador
        //Quero Obter um Livro

        //Como Administrador
        //Quero obter listagem de livros

        //Como Administrador
        //Quero Atualizar Estoque de um Livro

        //Como Usuário
        //Quero buscar um Livro
        //[Authorize(Roles = "User")] 
    }
}

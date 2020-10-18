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
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
               
        //Como Usuário
        //Quero criar meu cadastro        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser(UserRequest request)
        {
           var result = await _userService.CreateUser(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        //Como Usuário
        //Quero atualizar meu cadastro       
        [HttpPut]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> UpdateUser(UserRequest request)
        {
            var result = await _userService.UpdateUser(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        //Como administrador
        //Quero obter dados de usuário
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetUser(int id)
        {
            var result = await _userService.GetUser(id);          
            return Ok(result.Data);
        }

        //Como administrador
        //Quero ver listagem de Todos Usuários
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result.Data);
        }

        //Como administrador
        //Quero bloquer um usuário
        [HttpPut]
        [Route("{id}/block")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> BlockUser(int id)
        {
            var result = await _userService.BlockUser(id);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
    }
}

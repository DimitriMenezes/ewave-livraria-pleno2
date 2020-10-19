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
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _administratorService;
        public AdministratorController(IAdministratorService administratorService) 
        {
            _administratorService = administratorService;
        }

        //[Authorize(Roles="Administrator")]      
        //[Authorize(Roles = "User")]      

        //Como Administrador sem cadastro
        //Quero criar meu cadastro
        //Assume-se que existe algum mecanismo de aprovação do cadastro do Admin
        [HttpPost]
        public async Task<IActionResult> CreateAdministrator(AdministratorRequest request)
        {
            var result = await _administratorService.CreateAdministrator(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Como Administrador
        //Quero editar meus dados
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateAdministrator(AdministratorRequest request)
        {
            var result = await _administratorService.UpdateAdministrator(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }
    }
}

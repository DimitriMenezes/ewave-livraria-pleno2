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
    public class AuthentationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthentationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        //Dado que sou Administrador
        //Quero me autenticar
        [HttpPost]
        [Route("admin")]
        public async Task<IActionResult> AdminLogin(LoginRequest request)
        {
            var result = await _authenticationService.AdminLogin(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        //Dado que sou Usuário
        //Quero me autenticar
        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> UserLogin(LoginRequest request)
        {
            var result = await _authenticationService.UserLogin(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }       
    }
}

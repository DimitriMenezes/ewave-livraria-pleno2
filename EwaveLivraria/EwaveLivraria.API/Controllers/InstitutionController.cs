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
    public class InstitutionController : ControllerBase
    {        
        private readonly IInstitutionService _institutionService;
        public InstitutionController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        //Como Administrador
        //Quero Cadastrar uma Instituição
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> CreateInstitution(InstitutionRequest request)
        {
            var result = await _institutionService.CreateInstitution(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        //Como Administrador
        //Quero Editar uma Instituição
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateInstitution(InstitutionRequest request)
        {
            var result = await _institutionService.CreateInstitution(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        //Como Administrador
        //Quero Inativar uma Instituição
        [HttpPut]
        [Route("{id}/block")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> BlockInstitution(int id)
        {
            var result = await _institutionService.BlockInstitution(id);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        //Como Administrador ou Usuario
        //Quero visualizar uma instituição
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> GetInstitution(int id)
        {
            var result = await _institutionService.GetInstitution(id);           

            return Ok(result.Data);
        }

        //Como Administrador ou Usuario
        //Quero visualizar todas Instituições
        [HttpGet]        
        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> GetAllInstitutions()
        {
            var result = await _institutionService.GetAllInstitutions();
            return Ok(result.Data);
        }
    }
}

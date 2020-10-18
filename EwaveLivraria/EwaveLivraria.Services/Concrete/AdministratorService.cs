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
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IMapper _mapper;
        public AdministratorService(IAdministratorRepository administratorRepository, IMapper mapper)
        {
            _administratorRepository = administratorRepository;
            _mapper = mapper;
        }

        public async Task<ReturnModel> CreateAdministrator(AdministratorRequest request)
        {
            var adminValidator = new AdministratorValidator().Validate(request);
            if (!adminValidator.IsValid)
                return new ReturnModel { Errors = adminValidator.Errors };

            var admin = _mapper.Map<Administrator>(request);
            admin.Password = PasswordService.GeneratePassword(admin.Password);
            admin.RegisteredAt = DateTime.Now;

            await _administratorRepository.Insert(admin);
            return new ReturnModel { Data = 1};
        }
    }
}

using AutoMapper;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAdministratorRepository _administratorRepository;
        public AuthenticationService(IMapper mapper, IUserRepository userRepository, IAdministratorRepository administratorRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _administratorRepository = administratorRepository;
        }
        public async Task<ReturnModel> AdminLogin(LoginRequest request)
        {
            var admin = await _administratorRepository.GetByCpf(request.Cpf);
            if (admin == null)
                return new ReturnModel { Errors = "Usuário Inexistente" };

            var parts = admin.Password.Split('.', 3);

            if (!PasswordService.PasswordIsCorrect(parts[1], parts[2], request.Password))
                return new ReturnModel { Errors = "Senha Incorreta" };

            var token = TokenService.GenerateToken(admin);

            return new ReturnModel { Data = token };
        }

        public async Task<ReturnModel> UserLogin(LoginRequest request)
        {            
            var user = await _userRepository.GetByCpf(request.Cpf);
                        
            if (user == null)
                return new ReturnModel { Errors = "Usuário Inexistente" };

            var parts = user.Password.Split('.', 3);

            if (!PasswordService.PasswordIsCorrect(parts[1], parts[2], request.Password))
                return new ReturnModel { Errors = "Senha Incorreta" };

            var token = TokenService.GenerateToken(user);

            return new ReturnModel { Data = token };
        }
    }
}

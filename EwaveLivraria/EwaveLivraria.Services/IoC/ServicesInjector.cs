using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.IoC
{
    public static class ServicesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdministratorService, AdministratorService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IInstitutionService, InstitutionService>();
        }
    }
}

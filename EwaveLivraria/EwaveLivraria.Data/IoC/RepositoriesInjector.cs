using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Data.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Data.IoC
{
    public static class RepositoriesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookInventoryRepository, BookInventoryRepository>();
            services.AddScoped<IBookLoanRepository, BookLoanRepository>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

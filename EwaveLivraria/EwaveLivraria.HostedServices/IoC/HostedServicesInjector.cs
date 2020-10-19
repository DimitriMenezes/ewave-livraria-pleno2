using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;
using EwaveLivraria.Services.Mapper;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Data.Repositories.Concrete;
using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.Concrete;
using EwaveLivraria.HostedServices.BackgroundServices;
using EwaveLivraria.HostedServices.Extensions;

namespace EwaveLivraria.HostedServices.IoC
{
    public static class HostedServicesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {            
            var timezoneInfo = TimeZoneInfo.Local;

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServicesMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAdministratorRepository, AdministratorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookInventoryRepository, BookInventoryRepository>();
            services.AddTransient<IBookLoanRepository, BookLoanRepository>();
            services.AddTransient<IInstitutionRepository, InstitutionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IAdministratorService, AdministratorService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<IInstitutionService, InstitutionService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookLoanService, BookLoanService>();
            services.AddTransient<IUserService, UserService>();

            //CRON JOB
            //MINUTE | HOUR | DAY | MONTH | YEAR | DAY OF WEEK

            //As 00:00 de todos os dias
            //Verificar situação dos emprestimos em progresso que estão com atraso
            //E mudar situação para Emprésitmo com Devolução Atrasado
            services.AddCronJob<BookLoanVerifier>(c =>
            {
                c.TimeZoneInfo = timezoneInfo;
                c.CronExpression = @"0 0 * * *";                
            });

            //As 00:15 de todos os dias, 
            //bloquear usuários que não devolveram o livro na data correta
            services.AddCronJob<BlockUserWithBookReturnDelayed>(c =>
            {
                c.TimeZoneInfo = timezoneInfo;
                c.CronExpression = @"30 0 * * *";
            });

            //As 00:30 de todos os dias
            //Se o usuário está bloqueado, devolveu o livro,
            //e já passou o prazo de 30 dias, deve-se desbloquear ele
            services.AddCronJob<ReactivateUserBlocked>(c =>
            {
                c.TimeZoneInfo = timezoneInfo;
                c.CronExpression = @"30 0 * * *";               
            });

            //Enviar email ao administrador de todos os emprestimos que estão com devolução atrasada
            //O Envio é feito todo dia as 8 da manhã mostrando todos os usuarios com situação irregular
            services.AddCronJob<ReminderAdministrator>(c =>
            {
                c.TimeZoneInfo = timezoneInfo;
                c.CronExpression = @"* * * * *";
                //c.CronExpression = @"0 8 * * *";
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using EwaveLivraria.HostedServices.Extensions;
using Microsoft.Extensions.DependencyInjection;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Services.Abstract;

namespace EwaveLivraria.HostedServices.BackgroundServices
{
    public class ReminderAdministrator : CronJobService
    {        
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IEmailServices _emailServices;
        public ReminderAdministrator(IScheduleConfig<ReminderAdministrator> config, IServiceScopeFactory scopeFactory, IEmailServices emailServices)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _scopeFactory = scopeFactory;
            _emailServices = emailServices;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            await SendEmailForAdministratorAsync();
        }

        private async Task SendEmailForAdministratorAsync()
        {
            using var scope = _scopeFactory.CreateScope();
            var adminRepository = scope.ServiceProvider.GetRequiredService<IAdministratorRepository>();
            var bookLoansRepository = scope.ServiceProvider.GetRequiredService<IBookLoanRepository>();

            var admins = await adminRepository.GetAll();
            var bookLoans = await bookLoansRepository.GetBookLoansDelayed();
            if (bookLoans.Any())
            {
                await _emailServices.SendReminderAdmEmail(admins, bookLoans);
            }
        }
    }   
}

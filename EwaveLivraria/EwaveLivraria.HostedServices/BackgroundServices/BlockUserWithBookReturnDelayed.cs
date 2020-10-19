using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.HostedServices.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EwaveLivraria.HostedServices.BackgroundServices
{
    public class BlockUserWithBookReturnDelayed : CronJobService
    {
        private readonly IServiceScopeFactory _scopeFactory;
         public BlockUserWithBookReturnDelayed(IScheduleConfig<BlockUserWithBookReturnDelayed> config, IServiceScopeFactory scopeFactory)
          : base(config.CronExpression, config.TimeZoneInfo)
        {
            _scopeFactory = scopeFactory;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            await BlockUserWithBookReturnDelayedAsync();
        }

        private async Task BlockUserWithBookReturnDelayedAsync()
        {
            using var scope = _scopeFactory.CreateScope();            
            
            var bookLoansRepository = scope.ServiceProvider.GetRequiredService<IBookLoanRepository>();
            var bookLoans = await bookLoansRepository.GetBookLoansDelayed();
            if (bookLoans.Any())
            {
                foreach (var bookLoan in bookLoans)
                {
                    bookLoan.User.IsActive = false;
                    bookLoan.User.BlockedUntil = DateTime.Now.AddDays(30);
                    await bookLoansRepository.Update(bookLoan);
                }
            }
        }
    }
}

using EwaveLivraria.Data.Enums;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.HostedServices.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EwaveLivraria.HostedServices.BackgroundServices
{
    public class BookLoanVerifier : CronJobService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public BookLoanVerifier(IScheduleConfig<BookLoanVerifier> config, IServiceScopeFactory scopeFactory)
         : base(config.CronExpression, config.TimeZoneInfo)
        {
            _scopeFactory = scopeFactory;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            await VerifyAllLoansSituation();
        }

        private async Task VerifyAllLoansSituation()
        {
            using var scope = _scopeFactory.CreateScope();

            var bookLoansRepository = scope.ServiceProvider.GetRequiredService<IBookLoanRepository>();
            var bookLoans = await bookLoansRepository.GetBookLoansInProgress();
            if (bookLoans.Any())
            {
                foreach (var bookLoan in bookLoans)
                {
                   //Se ainda não houve devolução no prazo, mudar status
                   if(DateTime.Now > bookLoan.EndDate)
                    {
                        bookLoan.LoanStatusId = (int) BookLoanStatus.BookReturnDelayed;
                        await bookLoansRepository.Update(bookLoan);
                    }
                }
            }
        }
    }
}

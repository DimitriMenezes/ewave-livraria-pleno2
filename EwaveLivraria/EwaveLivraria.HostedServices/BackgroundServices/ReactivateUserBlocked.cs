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
    public class ReactivateUserBlocked : CronJobService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ReactivateUserBlocked(IScheduleConfig<ReactivateUserBlocked> config, IServiceScopeFactory scopeFactory)
           : base(config.CronExpression, config.TimeZoneInfo)
        {
            _scopeFactory = scopeFactory;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            await ReactivateBlockedUserAsync();
        }

        private async Task ReactivateBlockedUserAsync()
        {
            using var scope = _scopeFactory.CreateScope();
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();            
            var blockedUsers = await userRepository.GetBlockedUsers();
            if(blockedUsers.Any())
            {
                foreach (var user in blockedUsers)
                {
                    //Se já passou o prazo de 30 dias, desbloquear
                    if (DateTime.Now > user.BlockedUntil)
                    {
                        user.IsActive = true;
                        user.BlockedUntil = null;
                        await userRepository.Update(user);
                    }                    
                }
            } 
        }
    }
}


using EwaveLivraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Abstract
{
    public interface IEmailServices
    {
        Task SendReminderAdmEmail(List<Administrator> admins, List<BookLoan> loans);
    }
}

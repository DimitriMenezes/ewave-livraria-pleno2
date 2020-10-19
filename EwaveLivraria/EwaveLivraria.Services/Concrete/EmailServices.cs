using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.IO;
using EwaveLivraria.Services.Model.Response;
using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Domain.Model;

namespace EwaveLivraria.Services.Concrete
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _configuration;        
        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;            
        }

        public async Task SendReminderAdmEmail(List<Administrator> admins, List<BookLoan> loans)
        {
            foreach (var admin in admins)
            {
                var email = string.Format("<p>Olá, {0} </p>. <h1>Esse é a lista de usuários que ainda não devolveram os livros: </h1>", admin.Name);
                var body = "<ul> <li> CPF Usuário | Nome | Título do Livro | Autor | Data de devolução <li> {0} <ul>";
                var htmlLines = "";
                foreach (var loan in loans)
                { 
                    htmlLines += "<li>" + loan.User.Cpf +"|"+ loan.User.Name + "|" + loan.Book.Title + "|"+  loan.Book.Author + "|" + loan.EndDate + "</li>";
                }
                body = string.Format(body, htmlLines);
                email += body;
                await SendEmail(admin.Email, "Usuário com situação irregular", email, true);
            }            
        }
       
        private async Task SendEmail(string email, string subject, string body, bool isBodyHtml = false)
        {
            var settings = _configuration.GetSection("SMTP").Get<SmtpModel>();
            var client = new SmtpClient(settings.Host, settings.Port)
            {
                EnableSsl = settings.SSL == 1,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(settings.User, settings.Password)
            };

            var mailMessage = new MailMessage { From = new MailAddress(settings.From) };
               
            
            mailMessage.To.Add(email);
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.Body = body;
            mailMessage.Subject = subject;

            await client.SendMailAsync(mailMessage);
        }

    }
}
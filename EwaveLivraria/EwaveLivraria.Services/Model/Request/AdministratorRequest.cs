using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class AdministratorRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class LoginRequest
    {
        public string Cpf { get; set; }
        public string Password { get; set; }
    }
}

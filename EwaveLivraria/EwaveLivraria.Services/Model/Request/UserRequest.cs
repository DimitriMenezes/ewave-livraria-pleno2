using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }      
        public int InstitutionId { get; set; }      
        public AddressRequest Address { get; set; }
    }
}

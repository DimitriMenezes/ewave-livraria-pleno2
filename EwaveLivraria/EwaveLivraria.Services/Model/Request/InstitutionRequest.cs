using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class InstitutionRequest
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public AddressRequest Address { get; set; }
    }
}

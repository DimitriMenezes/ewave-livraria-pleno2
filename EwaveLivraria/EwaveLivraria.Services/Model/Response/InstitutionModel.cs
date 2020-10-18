using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Response
{
    public class InstitutionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsActive { get; set; }
        public AddressModel Address { get; set; }
    }
}

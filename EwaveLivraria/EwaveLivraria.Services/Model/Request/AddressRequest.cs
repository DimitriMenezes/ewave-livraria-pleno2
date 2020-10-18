using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class AddressRequest
    {
        public string Country { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}

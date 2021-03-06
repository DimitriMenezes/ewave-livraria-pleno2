﻿using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Response
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }       
        public int InstitutionId { get; set; }
        public AddressModel Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime BlockedUntil { get; set; }
    }
}

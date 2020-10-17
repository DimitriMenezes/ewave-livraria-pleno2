using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EwaveLivraria.Domain.Model
{
    [Table("Administrator")]
    public class Administrator : Base
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredAt { get; set; }     
    }
}

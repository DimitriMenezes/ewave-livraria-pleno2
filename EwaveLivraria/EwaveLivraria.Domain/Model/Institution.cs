using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EwaveLivraria.Domain.Model
{
    [Table("Institution")]
    public class Institution : Base
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsActive { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<User> User { get; set; }

        public Institution()
        {
            User = new Collection<User>();
        }
    }
}

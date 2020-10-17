using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EwaveLivraria.Domain.Model
{
    [Table("User")]
    public class User : Base
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime? BlockedUntil { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public int AddressId { get; set; }                
        public Address Address { get; set; }

        public ICollection<BookLoan> BookLoan { get; set; }

        public User()
        {
            BookLoan = new Collection<BookLoan>();
        }
    }
}

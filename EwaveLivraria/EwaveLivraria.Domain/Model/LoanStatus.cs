using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EwaveLivraria.Domain.Model
{
    [Table("LoanStatus")]
    public class LoanStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

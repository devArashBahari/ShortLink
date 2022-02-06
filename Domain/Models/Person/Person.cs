using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Person
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string IsDeleted { get; set; }
        public short? PersonType { get; set; }

        
        public bool IsLegal { get; set; }
        public string? FullName { get; set; }
        public int? Status { get; set; }
    }
}

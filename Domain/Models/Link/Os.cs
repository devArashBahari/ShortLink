using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Link
{
    public class Os
    {
        [Key]
        public int Id { get; set; }

        public string Family { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
    }
}

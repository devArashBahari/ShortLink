using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Link
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
   
        public bool IsBot { get; set; }
        public string Brand { get; set; }
        public string Family { get; set; }
        public string Model { get; set; }
    }
}

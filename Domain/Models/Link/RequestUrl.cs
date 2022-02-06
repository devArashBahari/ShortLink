using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Link
{
    public class RequestUrl
    {
        [Key]
        public int Id { get; set; }


        public int ShortUrlId { get; set; }
        public DateTime RequestDateTime { get; set; }


        public ShortUrl ShortUrl { get; set; }
    }
}

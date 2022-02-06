using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Link
{
    public class ShortUrl
    {
        [Key]
        public int Id { get; set; }
        public Uri OriginalUrl { get; set; }
        public Uri Value { get; set; }
        public string Token { get; set; }


        public ICollection<RequestUrl>requestUrls { get; set; }
    }
}

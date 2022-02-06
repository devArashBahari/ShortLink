using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Link
{
    public class UrlRequestDTO
    {


        public string OrginalUrl { get; set; }

        public enum UrlRequestResult
        {
            Success,
            Error
        }
    }
}

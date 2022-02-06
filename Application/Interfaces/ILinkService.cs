using Domain.Models.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.DTOs.Link.UrlRequestDTO;

namespace Application.Interfaces
{
    public interface ILinkService
    {
        ShortUrl QuickShortUrl(Uri uri);
        Task<UrlRequestResult> AddLink(ShortUrl url);
        Task AddUserAgent(string userAgnet);
        Task<ShortUrl> FindUrlByToken(string token);
    }
}

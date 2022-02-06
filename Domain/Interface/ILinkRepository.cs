using Domain.Models.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ILinkRepository : IAsyncDisposable
    {
       
        Task AddLink(ShortUrl url);
        Task AddOs(Os os);
        Task AddDevive(Device device);
        Task AddBrower(Browser brower);
        Task<ShortUrl> FindUrlByToken(string token);
        
        Task SaveChange();
    }
}

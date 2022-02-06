using Data.Context;
using Domain.Interface;
using Domain.Models.Link;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly ShortLinkContext _context;
        public LinkRepository(ShortLinkContext context)
        {
            _context = context;
        }

        public async Task AddBrower(Browser brower)
        {
            await _context.browsers.AddAsync(brower);
        }

        public async Task AddDevive(Device device)
        {
            await _context.devices.AddAsync(device);
        }

        public async Task AddLink(ShortUrl url)
        {
            
            await _context.AddAsync(url);
        }

        public async Task AddOs(Os os)
        {
            await _context.Os.AddAsync(os);
        }

        public async ValueTask DisposeAsync()
        {
            if (_context != null) await _context.DisposeAsync();
        }

        public async Task<ShortUrl> FindUrlByToken(string token)
        {
            return await _context.shortUrls.AsQueryable().SingleOrDefaultAsync(u => u.Token == token);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}

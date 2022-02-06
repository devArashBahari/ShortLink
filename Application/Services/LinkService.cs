using Application.Generator;
using Application.Interfaces;
using Domain.Interface;
using Domain.Models.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAParser;
using static Application.DTOs.Link.UrlRequestDTO;

namespace Application.Services
{
    public class LinkService : ILinkService
    {
        
        private readonly ILinkRepository _linkRepository;
        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }


       
        public ShortUrl QuickShortUrl(Uri uri)
        {
            var shortUrl = new ShortUrl();
            shortUrl.OriginalUrl = uri;
            shortUrl.Token = Generate.Token();
            shortUrl.Value = new Uri($"http://localhost:5016/{shortUrl.Token}");
            return shortUrl;
        }
        public async Task<UrlRequestResult> AddLink(ShortUrl url)
        {
            if (url == null) return UrlRequestResult.Error;

            await _linkRepository.AddLink(url);
            await _linkRepository.SaveChange();

            return UrlRequestResult.Success;
        }

        public async Task AddUserAgent(string userAgnet)
        {
            var uaParser = Parser.GetDefault();
            ClientInfo client = uaParser.Parse(userAgnet);

            var Os = new Os()
            {
                Family = client.OS.Family,
                Major = client.OS.Major,
                Minor = "No Data",
               
            };
            await _linkRepository.AddOs(Os);


            var device = new Domain.Models.Link.Device
            {
                IsBot = client.Device.IsSpider,
                Brand = client.Device.Brand,
                Family = client.Device.Family,
                Model = client.Device.Model,
                
            };
            await _linkRepository.AddDevive(device);

            var brower = new Browser
            {
                Family = client.UA.Family,
                Major = client.UA.Major,
                Minor = client.UA.Minor,
              
            };
            await _linkRepository.AddBrower(brower);
            await _linkRepository.SaveChange();
        }

        public async Task<ShortUrl> FindUrlByToken(string token)
        {
            return await _linkRepository.FindUrlByToken(token);
        }
    }
}

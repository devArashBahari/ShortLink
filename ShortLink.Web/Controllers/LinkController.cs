using Application.DTOs.Link;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.DTOs.Link.UrlRequestDTO;

namespace ShortLink.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService _linkService;
        public LinkController(ILinkService linkService)
        {
            _linkService = linkService;
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] UrlRequestDTO urlRequest)
        {

            if (urlRequest.OrginalUrl.Contains("https://") || urlRequest.OrginalUrl.Contains("http://"))
            {
                var url = new Uri(urlRequest.OrginalUrl);
                var shortUrl = _linkService.QuickShortUrl(url);

                var result = await _linkService.AddLink(shortUrl);
                switch (result)
                {
                    case UrlRequestResult.Error:
                        return BadRequest("مشکلی رخ داده است");
                        break;
                    case UrlRequestResult.Success:
                        return Ok(shortUrl.Value.ToString());
                        break;
                }

            }
            return BadRequest("لطفا لینک خود را با https یا http وارد نمایید");
        }
    }
}


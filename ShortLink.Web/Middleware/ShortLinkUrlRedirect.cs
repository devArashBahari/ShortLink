using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace ShortLink.Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ShortLinkUrlRedirect
    {
        private readonly RequestDelegate _next;
        private ILinkService _linkService;

        public ShortLinkUrlRedirect(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _linkService = (ILinkService)httpContext.RequestServices.GetService(typeof(ILinkService));
            var userAgent = StringValues.Empty;
            httpContext.Request.Headers.TryGetValue("User-Agent", out userAgent);

            if (httpContext.Request.Path.ToString().Length == 9)
            {
                await _linkService.AddUserAgent(userAgent);
                var token = httpContext.Request.Path.ToString().Substring(1);
                var shortUrl = await _linkService.FindUrlByToken(token);
                if (shortUrl != null)
                {
                    httpContext.Response.Redirect(shortUrl.OriginalUrl.ToString());
                    //var location = shortUrl.OriginalUrl.ToString();
                    //httpContext.Response.Headers.Location = new Uri((string)location);
                    //httpContext.Request.Path=shortUrl.OriginalUrl.ToString();
                }
                else
                {
                   httpContext.Response.Redirect(httpContext.Request.Host.ToString());
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ShortLinkUrlRedirectExtensions
    {
        public static IApplicationBuilder UseShortLinkUrlRedirect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShortLinkUrlRedirect>();
        }
    }
}

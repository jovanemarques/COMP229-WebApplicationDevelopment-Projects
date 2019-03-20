using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private UptimeService uptime;

        public ContentMiddleware(RequestDelegate next, UptimeService up)
        {
            nextDelegate = next;
            uptime = up;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync("Hello from middleware. " + $"I am up for {uptime.Uptime}", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}

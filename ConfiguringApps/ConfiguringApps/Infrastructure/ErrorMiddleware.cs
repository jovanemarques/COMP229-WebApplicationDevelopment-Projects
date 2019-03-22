using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;
        public ErrorMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await nextDelegate.Invoke(context);

            if(context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("Edge not supported", Encoding.UTF8);
            } else if (context.Response.StatusCode == 404)
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Error", Encoding.UTF8);
            }
        }
    }
}

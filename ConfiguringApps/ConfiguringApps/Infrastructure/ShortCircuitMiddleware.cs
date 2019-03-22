using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;
        public ShortCircuitMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Items["EdgeBrowser"] as bool? == true)
            {
                context.Response.StatusCode = 403;
            } else
            {
                await nextDelegate.Invoke(context);
            }
        }
    }
}

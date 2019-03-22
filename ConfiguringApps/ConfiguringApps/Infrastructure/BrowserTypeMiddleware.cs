﻿using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextDelegate;
        public BrowserTypeMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Items["EdgeBrowser"] = context.Request.Headers["User-Agent"]
                .Any(h => h.ToLower().Contains("edge"));
            await nextDelegate.Invoke(context);
        }
    }
}

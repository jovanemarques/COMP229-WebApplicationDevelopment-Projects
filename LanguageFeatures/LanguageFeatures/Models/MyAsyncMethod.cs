using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethod
    {
        //public static Task<long?> GetPageLength()
        //{
        //    HttpClient client = new HttpClient();
        //    var httpTask = client.GetAsync("http://google.com");

        //    return httpTask.ContinueWith((Task<HttpResponseMessage> a) => { return a.Result.Content.Headers.ContentLength; });
        //}
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://google.com");

            return httpMessage.Content.Headers.ContentLength;
        }
    }
}

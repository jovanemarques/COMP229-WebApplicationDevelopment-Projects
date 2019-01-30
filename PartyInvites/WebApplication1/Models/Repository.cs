using System.Collections.Generic;

namespace WebApplication1.Models
{
    public static class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();
        public static void AddResponse(GuestResponse aResponse)
        {
            responses.Add(aResponse);
        }
        public static IEnumerable<GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }
    }
}

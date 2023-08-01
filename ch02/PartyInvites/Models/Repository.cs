using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public static class Repository
    {
        private static Dictionary<string, GuestResponse> responses;

        static Repository()
        {
            responses = new Dictionary<string, GuestResponse>()
            {
                { "Bob", new GuestResponse { Name = "bob", Email = "bob@example.com", WillAttend = true } },
                { "Alice", new GuestResponse { Name = "alice", Email = "alice@example.com", WillAttend = true } },
                { "Paul", new GuestResponse { Name = "paul", Email = "paul@example.com", WillAttend = true } },
            };
         }

        public static void Add(GuestResponse newResponse)
        {
            string key = newResponse.Name.ToLowerInvariant();
            if (responses.ContainsKey(key))
            {
                responses[key] = newResponse;
            }
            else
            {
                responses.Add(key, newResponse);
            }
        }

        public static IEnumerable<GuestResponse> Responses
        {
            get { return responses.Values;  }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.Service
{
    public class ConnectAPI
    {
        public static string BookSocialAPI { get; set; }

        protected static HttpClient GetClient()
        {
            return new HttpClient { BaseAddress = new Uri(BookSocialAPI) };
        }
    }
}

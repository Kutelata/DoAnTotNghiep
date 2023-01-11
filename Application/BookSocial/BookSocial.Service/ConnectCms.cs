namespace BookSocial.Service
{
    public class ConnectCms
    {
        public static string BookSocialCms { get; set; }

        protected static HttpClient GetClient()
        {
            return new HttpClient { BaseAddress = new Uri(BookSocialCms) };
        }
    }
}

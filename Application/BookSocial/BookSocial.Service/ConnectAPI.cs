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

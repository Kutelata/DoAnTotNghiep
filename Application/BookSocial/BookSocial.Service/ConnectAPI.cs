namespace BookSocial.Service
{
    public class ConnectApi
    {
        public static string BookSocialApi { get; set; }

        protected static HttpClient GetClient()
        {
            return new HttpClient { BaseAddress = new Uri(BookSocialApi) };
        }
    }
}

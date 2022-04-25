namespace BookSocial.Service
{
    public class ConnectAdmin
    {
        public static string BookSocialAdmin { get; set; }

        protected static HttpClient GetClient()
        {
            return new HttpClient { BaseAddress = new Uri(BookSocialAdmin) };
        }
    }
}

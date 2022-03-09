using System.Data;
using System.Data.SqlClient;

namespace BookSocial.DataAccess
{
    public class ConnectionStrings
    {
        public static string BookSocialDB { get; set; }

        protected static IDbConnection GetConnection()
        {
            return new SqlConnection { ConnectionString = BookSocialDB };
        }
    }
}

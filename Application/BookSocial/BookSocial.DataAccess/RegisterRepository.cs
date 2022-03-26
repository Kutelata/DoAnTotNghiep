using BookSocial.DataAccess.DataAccessClass;
using BookSocial.DataAccess.DataAccessInterface;
using Microsoft.Extensions.DependencyInjection;

namespace BookSocial.DataAccess
{
    public class RegisterRepository
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IGenreRepository, GenreRepository>();
            service.AddScoped<IAuthorRepository, AuthorRepository>();
            service.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<IReviewRepository, ReviewRepository>();
        }
    }
}

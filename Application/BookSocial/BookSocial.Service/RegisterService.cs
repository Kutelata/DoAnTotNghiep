using BookSocial.Service.ServiceClass;
using BookSocial.Service.ServiceInterface;
using Microsoft.Extensions.DependencyInjection;

namespace BookSocial.Service
{
    public class RegisterService
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IGenreService, GenreService>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IAuthorBookService, AuthorBookService>();
            service.AddScoped<ICommentService, CommentService>();
            service.AddScoped<IShelfService, ShelfService>();
            service.AddScoped<IArticleService, ArticleService>();
        }
    }
}
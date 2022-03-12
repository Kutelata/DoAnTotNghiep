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
        }
    }
}
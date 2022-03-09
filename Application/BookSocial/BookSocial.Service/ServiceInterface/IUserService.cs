using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.Service.ServiceInterface
{
    public interface IUserService
    {
        public Task<UserSaveCookie> GetUserSaveCookie(LoginViewModel lvm);
    }
}

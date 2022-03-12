using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class UserRepository : ConnectionStrings, IUserRepository
    {
        public async Task<UserSaveCookie> GetUserSaveCookie(string account, string password)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<UserSaveCookie>(
                    @"SELECT 
                        u.id, u.[name] as 'userName', u.phone, u.email, 
                        u.account, u.password, u.image, u.address, u.description, 
                        u.birthday, u.gender, u.friend, u.status, r.[name] as 'role'
                    FROM [User] u
                    JOIN [ROLE] r ON u.role_id = r.id
                    WHERE u.account = @account and u.[password] = @password",
                    new { account, password });
            }
        }

        public Task<int> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

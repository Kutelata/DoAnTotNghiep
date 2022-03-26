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
                    WHERE u.account = @account COLLATE SQL_Latin1_General_CP1_CS_AS 
                        AND u.[password] = @password COLLATE SQL_Latin1_General_CP1_CS_AS",
                    new { account, password });
            }
        }

        public async Task<int> Create(User entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"INSERT INTO [User] 
                    VALUES (
                        @name, @phone, @email, @account, 
                        @password, @image, @address, @description, @birthday, 
                        @gender, @friend, @status, @roleId)",
                    entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM [User] WHERE id = @id", new { id });
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<User>(
                    @"SELECT 
                        id, [name], phone, email, account, [password], [image], 
                        [address], [description], birthday, gender, friend, [status], role_id as 'roleId'
                    FROM [User]");
            }
        }

        public async Task<User> GetById(int id)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<User>(
                    @"SELECT 
                        id, [name], phone, email, account, [password], [image], 
                        [address], [description], birthday, gender, friend, [status], role_id as 'roleId'
                    FROM [User] WHERE id = @id", new { id });
            }
        }

        public async Task<int> Update(User entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE [User]
                    SET 
                        [name] = @name, phone = @phone, email = @email, account = @account,
                        [password] = @password, [image] = @image, [address] = @address, 
                        [description] = @description, birthday = @birthday, gender = @gender,
                        friend = @friend, [status] = @status, role_id = @roleId
                    WHERE id = @id", entity);
            }
        }
    }
}

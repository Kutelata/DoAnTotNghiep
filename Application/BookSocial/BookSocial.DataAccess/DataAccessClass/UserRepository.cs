using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class UserRepository : ConnectionStrings, IUserRepository
    {
        public async Task<AdminSaveCookie> GetAdminSaveCookie(string account, string password)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<AdminSaveCookie>(
                    @"SELECT 
                        u.id, u.[name] as 'userName', u.account, u.password, 
                        u.[image], u.gender, u.status, u.[role]
                    FROM [User] u
                    WHERE u.account = @account COLLATE SQL_Latin1_General_CP1_CS_AS 
                        AND u.[password] = @password COLLATE SQL_Latin1_General_CP1_CS_AS 
                        AND u.[role] != 0
                        AND u.status != 0",
                    new { account, password });
            }
        }

        public async Task<UserSaveCookie> GetUserSaveCookie(string account, string password)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<UserSaveCookie>(
                    @"SELECT 
                        u.id, u.[name] as 'userName', u.phone, u.email, 
                        u.account, u.password, u.[image], u.address, u.description, 
                        u.birthday, u.gender, u.status, u.[role]
                    FROM [User] u
                    WHERE u.account = @account COLLATE SQL_Latin1_General_CP1_CS_AS 
                        AND u.[password] = @password COLLATE SQL_Latin1_General_CP1_CS_AS 
                        AND u.[role] = 0
                        AND u.status != 0",
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
                        @gender, @status, @role)",
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
                        [address], [description], birthday, gender, [status], [role]
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
                        [address], [description], birthday, gender, [status], [role]
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
                        [status] = @status, [role] = @role
                    WHERE id = @id", entity);
            }
        }

        public async Task<IEnumerable<UserStatistic>> GetUserStatistic()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<UserStatistic>(
                    @"SELECT 
	                    u.id,
						u.[name] as 'userName',
	                    u.email,
                        u.account,
						u.[image],
						u.gender,
                        u.[status],
						COUNT(f.[user_id]) as 'numberOfFriends',
                        COUNT(s.book_id) as 'numberBooksOnShelf',
						COUNT(r.id) as 'numberOfReviews',
						COUNT(c.id) as 'numberOfComments'
                    FROM [User] u 
					FULL OUTER JOIN Shelf s ON s.[user_id] = u.id
					FULL OUTER JOIN Review r ON r.[user_id] = u.id
					FULL OUTER JOIN Comment c ON c.[user_id] = u.id
					FULL OUTER JOIN Friend f ON f.[user_id] = u.id
					WHERE u.[role] = 0
                    GROUP BY u.id, u.[name], u.email, u.account, u.[image], u.gender, u.[status]");
            }
        }

        public async Task<IEnumerable<UserEmployeeStatistic>> GetUserEmployeeStatistic()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<UserEmployeeStatistic>(
                    @"SELECT 
	                    u.id,
						u.[name] as 'userName',
                        u.account,
                        u.[password],
						u.[image],
                        u.gender,
                        u.[status],
                        u.[role]
                    FROM [User] u WHERE u.[role] != 0");
            }
        }

        public async Task<User> GetByAccount(string userAccount)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<User>(
                    @"SELECT 
                        id, [name], phone, email, account, [password], [image], 
                        [address], [description], birthday, gender, [status], [role]
                    FROM [User] WHERE account = @userAccount", new { userAccount });
            }
        }

        public async Task<User> GetByEmail(string userEmail)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<User>(
                    @"SELECT 
                        id, [name], phone, email, account, [password], [image], 
                        [address], [description], birthday, gender, [status], [role]
                    FROM [User] WHERE email = @userEmail", new { userEmail });
            }
        }

        public async Task<IEnumerable<FriendList>> GetAllUser()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<FriendList>(
                    @"SELECT 
                        id, [name], [image], [description], gender, [status]
                    FROM [User] Where [status] != 0 AND [role] = 0");
            }
        }
    }
}
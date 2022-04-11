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
                        u.account, u.password, u.[image], u.address, u.description, 
                        u.birthday, u.gender, u.friend, u.status, u.[role]
                    FROM [User] u
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
                        @gender, @friend, @status, @role)",
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
                        [address], [description], birthday, gender, friend, [status], [role]
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
                        [address], [description], birthday, gender, friend, [status], [role]
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
                        friend = @friend, [status] = @status, [role] = @role
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
						COUNT(getUserFriend.userId) as 'numberOfFriends',
                        COUNT(s.book_id) as 'numberBooksOnShelf',
						COUNT(a.id) as 'numberOfArticles',
						COUNT(c.id) as 'numberOfComments'
                    FROM [User] u
					FULL OUTER JOIN 
                        (SELECT u.id as 'userId', splitUserFriend.value as 'userFriend'
					    FROM [User] u CROSS APPLY STRING_SPLIT(u.friend, ',') splitUserFriend
					    WHERE splitUserFriend.VALUE <> ''
					    GROUP BY splitUserFriend.VALUE, u.id) getUserFriend ON getUserFriend.userId = u.id
					FULL OUTER JOIN Shelf s ON s.[user_id] = u.id
					FULL OUTER JOIN Article a ON a.[user_id] = u.id
					FULL OUTER JOIN Comment c ON c.[user_id] = u.id
                    GROUP BY u.id, u.[name], u.email, u.account, u.[image], u.gender, u.friend, u.[status]");
            }
        }
    }
}
using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class FriendRepository : ConnectionStrings, IFriendRepository
    {
        public async Task<int> Create(Friend entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"INSERT INTO Friend VALUES (@userId, @userFriendId)",
                    entity);
            }
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteByUserAndUserFriendId(int userId, int userFriendId)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"DELETE FROM Friend WHERE user_id = @userId and user_friend_id = @userFriendId", 
                    new { userId, userFriendId });
            }
        }

        public Task<IEnumerable<Friend>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Friend> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Friend> GetByUserAndUserFriendId(int userId, int userFriendId)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Friend>(
                    @"SELECT 
                        user_id as 'userId', 
                        user_friend_id as 'userFriendId'
                    FROM Friend
                    WHERE user_id = @userId and user_friend_id = @userFriendId", new { userId, userFriendId });
            }
        }

        public async Task<double> GetTotalByUserAndUserFriendId(int userId, int userFriendId)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<double>(
                    @"SELECT COUNT(f.[user_id]) 
                    FROM Friend f 
                    WHERE f.[user_id] = @userId AND f.user_friend_id = @userFriendId", new { userId, userFriendId });
            }
        }

        public Task<int> Update(Friend entity)
        {
            throw new NotImplementedException();
        }
    }
}

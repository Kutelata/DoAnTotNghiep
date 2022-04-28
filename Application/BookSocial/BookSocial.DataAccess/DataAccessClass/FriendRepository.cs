using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class FriendRepository : ConnectionStrings, IFriendRepository
    {
        public Task<int> Create(Friend entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
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
                        user_friend_id as 'userFriendId',
                        confirm_friend as 'confirmFriend' 
                    FROM Friend
                    WHERE user_id = @userId and user_friend_id = @userFriendId", new { userId, userFriendId });
            }
        }

        public Task<int> Update(Friend entity)
        {
            throw new NotImplementedException();
        }
    }
}

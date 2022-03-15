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

        public Task<int> CreateReview(UserReview userReview)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditReview(UserReview userReview)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateShelft(UserShelf userShelf)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditShelft(UserShelf userShelf)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteShelft(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateBlog(UserBlog userBlog)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditBlog(UserBlog userBlog)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBlog(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateComment(UserComment userComment)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditComment(UserComment userComment)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateLike(UserLike userLike)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditLike(UserLike userLike)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteLike(int id)
        {
            throw new NotImplementedException();
        }
    }
}

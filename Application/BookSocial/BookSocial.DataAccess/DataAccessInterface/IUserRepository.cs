using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.DTO;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<UserSaveCookie> GetUserSaveCookie(string account, string password);

        // Action: Shelft
        public Task<int> CreateShelft(Shelf userShelf);
        public Task<int> UpdateShelft(Shelf userShelf);
        public Task<int> DeleteShelft(int id);
        // Action: Blog
        public Task<int> CreateBlog(Blog userBlog);
        public Task<int> UpdateBlog(Blog userBlog);
        public Task<int> DeleteBlog(int id);
        // Action: Comment
        public Task<int> CreateComment(Comment userComment);
        public Task<int> UpdateComment(Comment userComment);
        public Task<int> DeleteComment(int id);
        // Action: Like, Follow
        public Task<int> CreateLike(Like userLike);
        public Task<int> UpdateLike(Like userLike);
        public Task<int> DeleteLike(int id);
    }
}

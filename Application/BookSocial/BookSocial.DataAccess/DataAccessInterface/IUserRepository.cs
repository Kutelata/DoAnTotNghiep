using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.DTO;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<UserSaveCookie> GetUserSaveCookie(string account, string password);

        // Action: Review
        public Task<int> CreateReview(UserReview userReview);
        public Task<int> EditReview(UserReview userReview);
        public Task<int> DeleteReview(int id);
        // Action: Shelft
        public Task<int> CreateShelft(UserShelf userShelf);
        public Task<int> EditShelft(UserShelf userShelf);
        public Task<int> DeleteShelft(int id);
        // Action: Blog
        public Task<int> CreateBlog(UserBlog userBlog);
        public Task<int> EditBlog(UserBlog userBlog);
        public Task<int> DeleteBlog(int id);
        // Action: Comment
        public Task<int> CreateComment(UserComment userComment);
        public Task<int> EditComment(UserComment userComment);
        public Task<int> DeleteComment(int id);
        // Action: Like, Follow
        public Task<int> CreateLike(UserLike userLike);
        public Task<int> EditLike(UserLike userLike);
        public Task<int> DeleteLike(int id);
    }
}

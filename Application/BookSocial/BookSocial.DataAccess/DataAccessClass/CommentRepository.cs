using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class CommentRepository : ConnectionStrings, ICommentRepository
    {
        public async Task<int> Create(Comment entity)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<int>(
                    @"INSERT INTO Comment OUTPUT INSERTED.ID
                    VALUES (@text, @createdAt, @reviewId, @userId)",
                    entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Comment WHERE id = @id", new { id });
            }
        }

        public Task<IEnumerable<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetByReviewId(int reviewId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Comment>(
                    @"SELECT  
                        id, [text], 
                        created_at as 'createdAt', [review_id] as 'reviewId', 
                        [user_id] as 'userId'
                    FROM Comment WHERE review_id = @reviewId", new { reviewId });
            }
        }

        public async Task<Comment> GetById(int id)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Comment>(
                    @"SELECT 
                        id, [text], review_id as 'reviewId', created_at as 'createdAt', [user_id] as 'userId' FROM Comment WHERE id = @id",
                    new { id });
            }
        }

        public async Task<IEnumerable<Comment>> GetByUserId(int userId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Comment>(
                    @"SELECT  
                        id, [text], 
                        created_at as 'createdAt', [review_id] as 'reviewId', 
                        [user_id] as 'userId'
                    FROM Comment WHERE [user_id] = @userId", new { userId });
            }
        }

        public async Task<IEnumerable<CommentStatistic>> GetCommentStatistic()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<CommentStatistic>(
                    @"SELECT 
	                    c.id,
	                    c.[text],
						c.created_at as 'createdAt',
						r.id as 'reviewId',
						u.id as 'userId',
						u.[name] as 'userName'
                    FROM Comment c
					LEFT JOIN [User] u ON u.id = c.[user_id]
					LEFT JOIN Review r ON c.review_id = r.id
                    GROUP BY c.id, c.[text], c.created_at, r.id, u.id, u.[name]");
            }
        }

        public async Task<int> Update(Comment entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE Comment
                    SET 
                        [text] = @text, created_at = @createdAt, 
                        review_id = @reviewId, [user_id] = @userId
                    WHERE id = @id", entity);
            }
        }

        public async Task<IEnumerable<RecentActivityComment>> GetRecentActivityComment()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<RecentActivityComment>(
                    @"SELECT TOP 5
	                    u_comment.id AS 'userCommentId',
	                    u_comment.[name] AS 'userCommentName',
	                    u_review.id AS 'userReviewId',
	                    u_review.[name] AS 'userReviewName',
	                    b.id AS 'bookId',
	                    b.[name] AS 'bookName',
	                    c.created_at AS 'commentCreatedAt'
                    FROM Comment c
                    JOIN [User] u_comment ON u_comment.id = c.[user_id]
                    JOIN Review r ON r.id = c.review_id
                    JOIN [User] u_review ON u_review.id = r.[user_id]
                    JOIN Book b ON b.id = r.book_id
                    ORDER BY c.created_at DESC");
            }
        }
    }
}
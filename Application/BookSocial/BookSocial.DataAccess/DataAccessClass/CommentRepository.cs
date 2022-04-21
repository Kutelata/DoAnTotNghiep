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
                return await con.ExecuteAsync(
                    @"INSERT INTO Comment
                    VALUES (
                        @text, @parentId, @createdAt, @articleId, @userId)",
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
                        id, [text], parent_id, 
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
                        id, [text], article_id, parent_id, created_at, [user_id] FROM Comment WHERE id = @id",
                    new { id });
            }
        }

        public async Task<IEnumerable<Comment>> GetByParentId(int parentId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Comment>(
                    @"SELECT  
                        id, [text], parent_id, 
                        created_at as 'createdAt', [review_id] as 'reviewId', 
                        [user_id] as 'userId'
                    FROM Comment WHERE parent_id = @parentId", new { parentId });
            }
        }

        public async Task<IEnumerable<Comment>> GetByUserId(int userId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Comment>(
                    @"SELECT  
                        id, [text], parent_id, 
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
	                    c.id as 'commentId',
	                    c.[text],
						c.parent_id as 'parentId',
						c.created_at as 'createdAt',
						r.id as 'reviewId',
						u.id as 'userId',
						u.[name] as 'userName',
						COUNT(c.parent_id) as 'numberCommentReplies'
                    FROM Comment c
					LEFT JOIN [User] u ON u.id = c.[user_id]
					LEFT JOIN Review r ON c.review_id = r.id
                    GROUP BY c.id, c.[text], c.parent_id, c.created_at, r.id, u.id,u.[name]");
            }
        }

        public async Task<int> Update(Comment entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE Comment
                    SET 
                        [text] = @text, parent_id = @parentId, created_at = @createdAt, 
                        review_id = @reviewId, [user_id] = @userId
                    WHERE id = @id", entity);
            }
        }
    }
}

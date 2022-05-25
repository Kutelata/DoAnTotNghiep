using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class ReviewRepository : ConnectionStrings, IReviewRepository
    {
        public async Task<int> Create(Review entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"INSERT INTO Review OUTPUT INSERTED.ID
                    VALUES (
                        @text, @star, @createdAt, @bookId, @userId)",
                    entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Review WHERE id = @id", new { id });
            }
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Review>(@"SELECT id, [text], star, created_at, book_id, [user_id] FROM Review");
            }
        }

        public async Task<IEnumerable<ReviewStatistic>> GetReviewStatistic()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<ReviewStatistic>(
                    @"SELECT 
	                    r.id,
	                    r.[text],
						r.star,
						r.created_at AS 'createdAt',
						b.id AS 'bookId',
						b.[name] AS 'bookName',
						u.id AS 'userId',
						u.[name] AS 'userName',
						COUNT(c.id) AS 'numberOfComments'
                    FROM Review r
					LEFT JOIN [User] u ON u.id = r.[user_id]
					LEFT JOIN Comment c ON c.review_id = r.id
					LEFT JOIN Book b ON b.id = r.book_id
                    GROUP BY r.id, r.[text], r.star, r.created_at, b.id, b.[name], u.id, u.[name]");
            }
        }

        public async Task<IEnumerable<Review>> GetByBookId(int bookId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Review>(
                    @"SELECT 
                        id, [text], star, 
                        created_at AS 'createdAt', 
                        book_id AS 'bookId', 
                        [user_id] AS 'userId' 
                    FROM Review WHERE book_id = @bookId",
                    new { bookId });
            }
        }

        public async Task<Review> GetById(int id)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Review>(
                    @"SELECT 
                        id, [text], star, created_at, book_id, [user_id] FROM Review WHERE id = @id",
                    new { id });
            }
        }

        public async Task<IEnumerable<Review>> GetByUserId(int userId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Review>(
                    @"SELECT id, [text], star, created_at, book_id, [user_id] FROM Review WHERE [user_id] = @userId",
                    new { userId });
            }
        }

        public async Task<int> Update(Review entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE Review
                    SET 
                        [text] = @text, star = @star, created_at = @createdAt, 
                        book_id = @bookId, [user_id] = @userId
                    WHERE id = @id", entity);
            }
        }

        public async Task<IEnumerable<ReviewList>> GetReviewList()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<ReviewList>(
                    @"SELECT 
	                    r.id AS 'reviewId',
	                    u.id AS 'userId',
						u.[name] AS 'userName',
						u.[image] AS 'userImage',
						r.created_at AS 'createdAt',
						s.progress_read AS 'userProgressRead',
						r.[text],
						r.star,
						b.id AS 'bookId',
						b.[image] AS 'bookImage',
						b.[name] AS 'bookName',
						b.[description] AS 'bookDescription'
                    FROM Review r
					LEFT JOIN [User] u ON u.id = r.[user_id]
					LEFT JOIN Shelf s ON s.[user_id] = r.[user_id] AND s.book_id = r.book_id
					LEFT JOIN Book b ON b.id = r.book_id
                    WHERE u.status != 0
					ORDER BY created_at DESC");
            }
        }

        public async Task<double> GetTotalByUserId(int userId)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<double>(
                    @"SELECT COUNT(r.[user_id]) 
                    FROM Review r
                    WHERE r.[user_id] = @userId", new { userId });
            }
        }
    }
}

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
                    @"INSERT INTO Review
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
						r.created_at as 'createdAt',
						b.id as 'bookId',
						b.[name] as 'bookName',
						u.id as 'userId',
						u.[name] as 'userName',
						COUNT(c.id) as 'numberOfComments'
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
                    @"SELECT id, [text], star, created_at, book_id, [user_id] FROM Review WHERE book_id = @bookId",
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
    }
}

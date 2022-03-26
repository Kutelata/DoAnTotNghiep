using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class ReviewRepository : ConnectionStrings, IReviewRepository
    {
        public async Task<int> Create(Article entity)
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

        public Task<IEnumerable<Article>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(Article entity)
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

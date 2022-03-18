using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;
using System.Data;

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
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Review WHERE id = @id", parameters);
            }
        }

        public Task<IEnumerable<Review>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetById(int id)
        {
            throw new NotImplementedException();
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

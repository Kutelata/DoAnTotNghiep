using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class ArticleRepository : ConnectionStrings, IArticleRepository
    {
        public async Task<int> Create(Article entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"INSERT INTO Article
                    VALUES (
                        @text, @star, @createdAt, @bookId, @userId)",
                    entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Article WHERE id = @id", new { id });
            }
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Article>(@"SELECT id, [text], star, created_at, book_id, [user_id] FROM Article");
            }
        }

        public async Task<IEnumerable<Article>> GetByBookId(int bookId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Article>(
                    @"SELECT id, [text], star, created_at, book_id, [user_id] FROM Article WHERE book_id = @bookId", 
                    new { bookId });
            }
        }

        public async Task<Article> GetById(int id)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Article>(
                    @"SELECT 
                        id, [text], star, created_at, book_id, [user_id] FROM Article WHERE id = @id",
                    new { id });
            }
        }

        public async Task<int> Update(Article entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE Article
                    SET 
                        [text] = @text, star = @star, created_at = @createdAt, 
                        book_id = @bookId, [user_id] = @userId
                    WHERE id = @id", entity);
            }
        }
    }
}

using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
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

        public async Task<IEnumerable<ArticleStatistic>> GetArticleStatistic()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<ArticleStatistic>(
                    @"SELECT 
	                    a.id as 'articleId',
	                    a.[text],
						a.star,
						a.created_at as 'createdAt',
						b.id as 'bookId',
						b.[name],
						u.id as 'userId',
						u.[name] as 'userName',
						COUNT(c.id) as 'numberOfComments'
                    FROM Article a
					LEFT JOIN [User] u ON u.id = a.[user_id]
					LEFT JOIN Comment c ON c.article_id = a.id
					LEFT JOIN Book b ON b.id = a.book_id
                    GROUP BY a.id, a.[text], a.star, a.created_at, b.id, b.[name], u.id, u.[name]");
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

        public async Task<IEnumerable<Article>> GetByUserId(int userId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Article>(
                    @"SELECT id, [text], star, created_at, book_id, [user_id] FROM Article WHERE [user_id] = @userId",
                    new { userId });
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

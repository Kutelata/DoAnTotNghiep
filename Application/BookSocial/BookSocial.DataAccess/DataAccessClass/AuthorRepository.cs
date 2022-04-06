using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class AuthorRepository : ConnectionStrings, IAuthorRepository
    {
        public async Task<int> Create(Author entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"INSERT INTO Author VALUES (@name, @image, @description, @birthday)", entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Author WHERE id = @id", new { id });
            }
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Author>(@"SELECT id, [name], [image], [description], birthday FROM Author");
            }
        }

        public async Task<IEnumerable<AuthorStatistic>> GetAuthorStatistic()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<AuthorStatistic>(
                    @"SELECT 
	                    a.id,
	                    a.[name] as 'authorName',
						a.[image],
						a.[description],
						a.birthday,
						COUNT(ab.book_id) as 'numberOfBooks'
                    FROM Author a
					LEFT JOIN Author_Book ab ON ab.author_id = a.id
                    GROUP BY a.id, a.[name], a.[image], a.[description], a.birthday");
            }
        }

        public async Task<Author> GetById(int id)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Author>(
                    @"SELECT 
                        id, [name], [image], [description], birthday FROM Author WHERE id = @id",
                    new { id });
            }
        }

        public async Task<int> Update(Author entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE Author 
                    SET 
                        [name] = @name, [image] = @image, 
                        [description] = @description, birthday = @birthday
                    WHERE id = @id",
                    entity);
            }
        }
    }
}

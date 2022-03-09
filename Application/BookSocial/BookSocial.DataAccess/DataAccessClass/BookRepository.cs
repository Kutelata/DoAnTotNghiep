using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class BookRepository : ConnectionStrings, IBookRepository
    {
        public async Task<int> Create(Book entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"INSERT INTO Book
                        (isbn, [name], [image], [description], [page_number], published, language, genre_id) 
                    VALUES 
                        (@isbn, @name, @image, @description, @pageNumber, @published, @language, @genreId)",
                    entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Book WHERE id = @id", id);
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Book>(@"SELECT * FROM Book");
            }
        }

        public async Task<Book> GetById(int id)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Book>(@"SELECT * FROM Book WHERE id = @id", id);
            }
        }

        public async Task<int> Update(Book entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE Book 
                    SET 
                        isbn = @isbn, [name] = @name, [image] = @image, 
                        [description] = @description, [page_number] = @pageNumber, 
                        published = @published, language = @language, genre_id = @genreId
                    WHERE id = @id", 
                    entity);
            }
        }
    }
}

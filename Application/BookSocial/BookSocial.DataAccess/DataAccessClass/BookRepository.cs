using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;
using System.Data;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class BookRepository : ConnectionStrings, IBookRepository
    {
        public async Task<int> Create(Book entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"INSERT INTO Book VALUES (@isbn, @name, @image, @description, @pageNumber, @published, @genreId)", entity);
            }
        }

        public async Task<int> CreateAuthorBook(AuthorBook authorBook)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"INSERT INTO AuthorBook VALUES (@bookId, @authorId)", authorBook);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Book WHERE id = @id", new { id });
            }
        }

        public async Task<int> DeleteAuthorBook(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Author_Book WHERE book_id = @id", new { id });
            }
        }

        public async Task<int> UpdateAuthorBook(AuthorBook authorBook)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE Author_Book SET book_id = @bookId, author_id = @authorId)", authorBook);
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Book>(
                    @"SELECT 
                        id, isbn, [name], [image], [description], 
                        page_number as 'pageNumber', published, 
                        genre_id as 'genreId'
                    FROM Book");
            }
        }

        public async Task<Book> GetById(int id)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Book>(
                    @"SELECT  
                        id, isbn, [name], [image], [description], 
                        page_number as 'pageNumber', published, 
                        genre_id as 'genreId'
                    FROM Book WHERE id = @id", new { id });
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
                        published = @published, genre_id = @genreId
                    WHERE id = @id",
                    entity);
            }
        }

        public async Task<IEnumerable<Book>> GetByGenreId(int genreId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Book>(
                    @"SELECT  
                        id, isbn, [name], [image], [description], 
                        page_number as 'pageNumber', published, 
                        genre_id as 'genreId'
                    FROM Book WHERE genre_id = @genreId", new { genreId });
            }
        }
    }
}

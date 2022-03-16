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

        public Task<int> CreateAuthorBook(AuthorBook authorBook)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Book WHERE id = @id", parameters);
            }
        }

        public Task<int> DeleteAuthorBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditAuthorBook(AuthorBook authorBook)
        {
            throw new NotImplementedException();
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
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Book>(
                    @"SELECT  
                        id, isbn, [name], [image], [description], 
                        page_number as 'pageNumber', published, 
                        genre_id as 'genreId'
                    FROM Book WHERE id = @id", parameters);
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
    }
}

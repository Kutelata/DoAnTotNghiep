using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        (@isbn, @name, @image, @desciption, @page_number, @published, @language, @genre_id)",
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
                    @"UPDATE Books 
                    SET 
                        isbn = @isbn, [name] = @name, [image] = @image, 
                        [description] = @description, [page_number] = @page_number, 
                        published = @published, language = @language, genre_id = @genre_id)
                    WHERE id = @id", 
                    entity);
            }
        }
    }
}

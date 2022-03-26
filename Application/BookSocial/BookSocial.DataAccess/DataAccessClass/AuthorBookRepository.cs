using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class AuthorBookRepository : ConnectionStrings, IAuthorBookRepository
    {
        public async Task<int> Create(AuthorBook entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"INSERT INTO AuthorBook VALUES (@bookId, @authorId)", entity);
            }
        }

        public async Task<int> Delete(int bookId, int authorId)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"DELETE FROM Author_Book WHERE book_id = @bookId and author_id = @authorId",
                    new { bookId, authorId });
            }
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorBook>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorBook> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(AuthorBook entity)
        {
            throw new NotImplementedException();
        }
    }
}

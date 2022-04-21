using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class ShelfRepository : ConnectionStrings, IShelfRepository
    {
        public Task<int> Create(Shelf entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shelf>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Shelf> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Shelf entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shelf>> GetByBookId(int bookId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Shelf>(
                    @"SELECT progress_read as 'progressRead', book_id as 'bookId', 
                    [user_id] as 'userId' FROM Shelf WHERE book_id = @bookId",
                    new { bookId });
            }
        }

        public async Task<IEnumerable<Shelf>> GetByUserId(int userId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Shelf>(
                    @"SELECT progress_read as 'progressRead', book_id as 'bookId', 
                    [user_id] as 'userId' FROM Shelf WHERE [user_id] = @userId",
                    new { userId });
            }
        }
    }
}

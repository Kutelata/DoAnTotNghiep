﻿using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
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

        public async Task<int> Update(Shelf entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"UPDATE Shelf
                    SET 
                        progress_read = @progressRead,
                        book_id = @bookId, [user_id] = @userId
                    WHERE book_id = @bookId and user_id = @userId", entity);
            }
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

        public async Task<IEnumerable<ShelfDetail>> GetByShelfDetail(int userId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<ShelfDetail>(
                    @"SELECT 
	                    s.[user_id] as 'userId',
	                    g.id as 'genreId',
	                    g.[name] as 'genreName',
	                    b.id as 'bookId',
	                    b.[name] as 'bookName',
	                    b.[image] as 'bookImage',
	                    b.[description] as 'bookDescription',
	                    s.progress_read as 'progressRead',
						COUNT(r.id) as 'NumberOfReviews',
                        AVG(cast(NULLIF(r.star, 0) AS BIGINT)) as 'AverageOfRating'
                    FROM [User] u
                    JOIN Shelf s ON s.user_id = u.id
                    JOIN Book b ON b.id = s.book_id
                    JOIN Genre g ON g.id = b.genre_id
					JOIN Review r ON r.book_id = s.book_id
                    WHERE u.id = @userId
					GROUP BY s.[user_id], g.id, g.[name], b.id, b.[name], 
                        b.[image], b.[description], s.progress_read", new { userId });
            }
        }

        public async Task<int> DeleteByBookAndUserId(int bookId, int userId)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(
                    @"DELETE FROM Shelf WHERE book_id = @bookId and user_id = @userId", 
                    new { bookId, userId });
            }
        }
    }
}

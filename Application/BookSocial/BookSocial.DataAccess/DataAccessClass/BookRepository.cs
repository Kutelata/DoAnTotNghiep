using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
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
                    @"INSERT INTO Book VALUES (@isbn, @name, @image, @description, @pageNumber, @published, @genreId)", entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Book WHERE id = @id", new { id });
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

        public async Task<IEnumerable<BookStatistic>> GetBookStatistic()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<BookStatistic>(
                    @"SELECT 
	                    b.id,
						b.isbn,
	                    b.[name] as 'bookName',
						b.[image],
						b.published,
						g.[name] as 'genreName',
						COUNT(ab.author_id) as 'numberOfAuthors',
	                    COUNT(r.id) as 'numberOfReviews',
						COUNT(s.[user_id]) as 'numberOfShelfs'
                    FROM Book b
					JOIN Genre g ON g.id = b.genre_id
                    FULL OUTER JOIN Review r ON r.book_id = b.id
					FULL OUTER JOIN Author_Book ab ON ab.book_id = b.id
					FULL OUTER JOIN Shelf s ON s.book_id = b.id
                    GROUP BY b.id, b.isbn, b.[name], b.[image], b.published, g.[name]");
            }
        }

        public async Task<Book> GetByIsbn(string isbn)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Book>(
                    @"SELECT  
                        id, isbn, [name], [image], [description], 
                        page_number as 'pageNumber', published, 
                        genre_id as 'genreId'
                    FROM Book WHERE isbn = @isbn", new { isbn });
            }
        }

        public async Task<IEnumerable<BookListByAuthorId>> GetBookListByAuthorId(int authorId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<BookListByAuthorId>(
                    @"SELECT 
	                    b.id AS 'BookId',
                        b.[name] AS 'BookName',
                        b.[image] AS 'BookImage'
                    FROM Author_Book ab 
                    JOIN author a ON a.id = ab.author_id
                    JOIN book b ON b.id = ab.book_id
                    WHERE ab.author_id = @authorId", new { authorId });
            }
        }

        public async Task<SingleBookCurrentlyReading> GetSingleBookCurrentlyReading(int userId)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<SingleBookCurrentlyReading>(
                    @"SELECT TOP 1
	                    b.id AS 'BookId',
                        b.[name] AS 'BookName',
                        b.[image] AS 'BookImage'
                    FROM Shelf s 
                    JOIN [User] u ON u.id = s.[user_id]
                    JOIN Book b ON b.id = s.book_id
                    WHERE u.id = @userId and s.progress_read = 1", new { userId });
            }
        }

        public async Task<IEnumerable<SearchBook>> GetSearchBook()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<SearchBook>(
                    @"SELECT 
	                    g.id AS 'genreId',
	                    g.[name] AS 'genreName',
	                    b.id AS 'bookId',
	                    b.[name] AS 'bookName',
	                    b.[image] AS 'bookImage',
	                    b.[description] AS 'bookDescription',
						COUNT(r.id) AS 'NumberOfReviews',
                        AVG(cast(NULLIF(r.star, 0) AS BIGINT)) AS 'AverageOfRating'
                    FROM Book b 
                    LEFT JOIN Genre g ON g.id = b.genre_id
					LEFT JOIN Review r ON r.book_id = b.id
					GROUP BY g.id, g.[name], b.id, b.[name], 
                        b.[image], b.[description]");
            }
        }
    }
}

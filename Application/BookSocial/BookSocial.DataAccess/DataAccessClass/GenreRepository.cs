using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using Dapper;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class GenreRepository : ConnectionStrings, IGenreRepository
    {
        public async Task<int> Create(Genre entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"INSERT INTO Genre([name])VALUES(@name)", entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"DELETE FROM Genre WHERE id = @id", id);
            }
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Genre>(@"SELECT * FROM Genre");
            }
        }

        public async Task<Genre> GetById(int id)
        {
            using (var con = GetConnection())
            {
                return await con.QuerySingleAsync<Genre>(@"SELECT * FROM Genre WHERE id = @id", id);
            }
        }

        public async Task<IEnumerable<GenreStatistic>> GetGenreStatistic()
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<GenreStatistic>(
                    @"SELECT 
	                    g.id,
	                    g.name,
	                    COUNT(b.id) as 'numberOfBooks'
                    FROM Genre g
                    FULL OUTER JOIN Book b ON b.genre_id = g.id
                    GROUP BY g.id,g.name");
            }
        }

        public async Task<int> Update(Genre entity)
        {
            using (var con = GetConnection())
            {
                return await con.ExecuteAsync(@"UPDATE Genre SET [name] = @name WHERE id = @id", entity);
            }
        }
    }
}

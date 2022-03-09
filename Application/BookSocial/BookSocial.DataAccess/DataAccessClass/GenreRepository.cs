using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetById(int id)
        {
            throw new NotImplementedException();
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

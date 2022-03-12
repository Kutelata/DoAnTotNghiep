using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<GenreStatistic> GetGenreStatistic();
    }
}

using BookSocial.EntityClass.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSocial.Service.ServiceInterface
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetByGenreId(int genreId);
    }
}

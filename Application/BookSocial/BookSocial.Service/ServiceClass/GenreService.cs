using BookSocial.EntityClass.DTO;
using BookSocial.Service.ServiceInterface;

namespace BookSocial.Service.ServiceClass
{
    public class GenreService : ConnectAPI, IGenreService
    {
        public Task<GenreStatistic> GetGenreStatistic()
        {
            throw new NotImplementedException();
        }
    }
}

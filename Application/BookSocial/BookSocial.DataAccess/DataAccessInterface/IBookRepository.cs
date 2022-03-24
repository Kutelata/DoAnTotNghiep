using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessInterface
{
    public interface IBookRepository : IRepository<Book>
    {
        public Task<IEnumerable<Book>> GetByGenreId(int genreId);

        // Action: Assign Author
        public Task<int> CreateAuthorBook(AuthorBook authorBook);
        public Task<int> UpdateAuthorBook(AuthorBook authorBook);
        public Task<int> DeleteAuthorBook(int id);
    }
}

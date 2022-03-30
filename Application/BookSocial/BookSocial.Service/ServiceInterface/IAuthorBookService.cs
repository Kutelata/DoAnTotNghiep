using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IAuthorBookService
    {
        Task<IEnumerable<AuthorBook>> GetByBookId(int bookId);
        Task<int> Delete(int bookId, int authorId);
    }
}

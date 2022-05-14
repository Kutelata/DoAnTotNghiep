using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<IEnumerable<AuthorStatistic>> GetAuthorStatistic();
        Task<IEnumerable<SearchAuthor>> GetSearchAuthor();
        Task<IEnumerable<AuthorListByBookId>> GetAuthorListByBookId(int bookId);
        Task<Author> GetById(int authorId);
        Task<int> Create(Author author);
        Task<int> Update(Author author);
        Task<int> Delete(int authorId);
    }
}

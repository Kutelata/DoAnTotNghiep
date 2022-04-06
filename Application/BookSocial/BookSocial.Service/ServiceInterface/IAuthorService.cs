using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAll();
        public Task<IEnumerable<AuthorStatistic>> GetAuthorStatistic();
        public Task<Author> GetById(int authorId);
        public Task<int> Create(Author author);
        public Task<int> Update(Author author);
        public Task<int> Delete(int authorId);
    }
}

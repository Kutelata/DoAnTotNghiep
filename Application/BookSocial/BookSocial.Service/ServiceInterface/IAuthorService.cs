using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAll();
        public Task<Author> GetById(int authorId);
        public Task<int> Create(Author author);
        public Task<int> Update(Author author);
        public Task<int> Delete(int authorId);
    }
}

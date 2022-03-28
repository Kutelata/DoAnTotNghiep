using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;

namespace BookSocial.DataAccess.DataAccessClass
{
    public class CommentRepository : ConnectionStrings, ICommentRepository
    {
        public Task<int> Create(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}

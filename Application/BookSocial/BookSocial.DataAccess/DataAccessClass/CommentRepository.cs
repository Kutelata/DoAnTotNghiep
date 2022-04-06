using BookSocial.DataAccess.DataAccessInterface;
using BookSocial.EntityClass.Entity;
using Dapper;

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

        public async Task<IEnumerable<Comment>> GetByArticleId(int articleId)
        {
            using (var con = GetConnection())
            {
                return await con.QueryAsync<Comment>(
                    @"SELECT  
                        id, [text], parent_id, 
                        created_at as 'createdAt', [article_id] as 'articleId', 
                        [user_id] as 'userId'
                    FROM Comment WHERE article_id = @articleId", new { articleId });
            }
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

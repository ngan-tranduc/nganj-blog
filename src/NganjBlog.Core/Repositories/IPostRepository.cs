using NganjBlog.Core.Domain.Content;
using NganjBlog.Data.SeedWorks;

namespace NganjBlog.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
    }
}

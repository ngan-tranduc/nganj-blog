using Microsoft.EntityFrameworkCore;
using NganjBlog.Core.Domain.Content;
using NganjBlog.Core.Repositories;
using NganjBlog.Data.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganjBlog.Data.Repositories
{
    public class PostRepository:RepositoryBase<Post,Guid>, IPostRepository
    {
        public PostRepository(NganjBlogContext context) : base(context)
        {
        }

        Task<List<Post>> IPostRepository.GetPopularPostsAsync(int count)
        {
            return _context.Posts.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
        }
    }
}

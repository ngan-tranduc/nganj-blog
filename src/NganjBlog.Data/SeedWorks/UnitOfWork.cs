using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganjBlog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NganjBlogContext _context;
        public UnitOfWork(NganjBlogContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

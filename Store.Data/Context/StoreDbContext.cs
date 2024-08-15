using Microsoft.EntityFrameworkCore;
using Store.Core.Models;

namespace Store.Data.Context
{
    public class StoreDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> opt) : base(opt)
        {
            
        }
    }
}

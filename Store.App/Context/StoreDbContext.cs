using Microsoft.EntityFrameworkCore;
using Store.App.Models;

namespace Store.App.Context
{
    public class StoreDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> opt) : base(opt)
        {
            
        }
    }
}

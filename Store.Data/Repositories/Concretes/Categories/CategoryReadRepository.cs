using Store.Core.Models;
using Store.Core.Repositories.Abstractions.Categories;
using Store.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories.Concretes.Categories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(StoreDbContext context) : base(context)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Store.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table { get; }
    }
}

using Store.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Repositories.Abstractions
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsync();
        IQueryable<T> GetAllWhereAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] include);
        Task<T?> GetById(string id);
        Task<T?> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] include);
    }
}

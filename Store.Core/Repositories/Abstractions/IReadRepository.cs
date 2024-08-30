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
        IQueryable<T> GetAllAsync(bool isTracking = true);
        IQueryable<T> GetAllWhereAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes);
        Task<T?> GetById(string id, bool isTracking = true, params string[] includes);
        Task<T?> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes);
    }
}

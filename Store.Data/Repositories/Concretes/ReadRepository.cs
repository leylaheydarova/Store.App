using Microsoft.EntityFrameworkCore;
using Store.Core.Models.BaseModels;
using Store.Core.Repositories.Abstractions;
using Store.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories.Concretes
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext _context;

        public ReadRepository(StoreDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAllAsync(bool isTracking = true)
        {
            var query = Table;
            if (!isTracking)
            {
                query.AsNoTracking();
            }
            return query;
        }

        public IQueryable<T> GetAllWhereAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes)
        {
            var query = Table.Where(expression);
            if (!isTracking)
            {
                query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public async Task<T?> GetById(string id, bool isTracking = true, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
            {
                query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return entity;
        }

        public async Task<T?> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
            {
                query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(expression);
            return entity;
        }
    }
}

using BulkyBook.Data;
using BulkyBook.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
	{
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        void IRepository<T>.Add(T entity)
        {
            dbSet.Add(entity);
        }

        IEnumerable<T> IRepository<T>.GetAll(string? includeProperties=null)
        {
            IQueryable<T> query = dbSet;
			if (includeProperties != null)
			{
				foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(item);
				}
			}
			return query.ToList();
        }

        T IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
			if (includeProperties != null)
			{
				foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(item);
				}
			}
			return query.FirstOrDefault();
        }

        void IRepository<T>.Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        void IRepository<T>.RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

		//void IRepository<T>.Update(T entity)
		//{
		//	dbSet.Attach(entity);
		//	_context.Entry(entity).State = EntityState.Modified;
		//}
	}
}

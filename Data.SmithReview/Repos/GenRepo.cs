using Data.SmithReview.Domain;
using Data.SmithReview.Domain.Extensions;
using Data.SmithReview.Domain.Interfaces;
using Data.SmithReview.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.SmithReview.Repos {
    public class GenRepo<TContext, TDomain> : IGenRepo<TContext, TDomain>
            where TDomain : BaseDomainModel
            where TContext : IDbContext {
        public GenRepo(TContext context) {
            _context = context;
            _dbSet = context.Set<TDomain>();
        }

        protected TContext _context;
        protected DbSet<TDomain> _dbSet;
        protected IQueryable<TDomain> _query;
        public virtual GenRepo<TContext, TDomain> Include(params string[] includedProperties) {
            _query = _dbSet;
            foreach(string include in includedProperties) {
                _query = _query.Include(include);
            }
            return this;
        }

        public virtual IEnumerable<TDomain> Query(
                Expression<Func<TDomain, bool>> predicate = null,
                int page = 0,
                int perPage = 0,
                params string[] orderBy) {
            return Query<TDomain>((x)=>x, predicate, page, perPage, orderBy);
        }
        public virtual IEnumerable<TResult> Query<TResult>(
                Expression<Func<TDomain, TResult>> select,
                Expression<Func<TDomain, bool>> predicate = null,
                int page = 0,
                int perPage = 0,
                params string[] orderBy) {
            IQueryable<TDomain> query = _query ?? _dbSet;
            IOrderedQueryable<TResult> orderedQuery = null;
            IQueryable<TResult> projectedQuery = null;
            if (predicate != null) query = query.Where(predicate);
            projectedQuery = query.Select(select);
            if (orderBy != null) {
                foreach(string column in orderBy){
                    char firstChar = column.First();
                    string columnName = firstChar == '+' || firstChar == '-' ? column.Substring(1) : column;
                    Expression<Func<TDomain, object>> propertyExpression = (x)=> x.GetType().GetProperty(columnName).GetValue(x);
                    if (orderedQuery != null)
                        orderedQuery = firstChar == '-' ? orderedQuery.ThenByDescending(columnName) : orderedQuery.ThenBy(columnName);
                    else
                        orderedQuery = firstChar == '-' ?  projectedQuery.OrderByDescending(columnName) : projectedQuery.OrderBy(columnName);
                }
            }
            projectedQuery = (orderedQuery ?? projectedQuery);
            if (page > 0 && perPage > 0)
                projectedQuery = projectedQuery
                    .Skip((page - 1) * perPage)
                    .Take(perPage);
            return projectedQuery.ToList();
        }
        public virtual void Upsert(TDomain item) {
            if (item.HasEmptyId()) {
                _dbSet.Add(item);
            }
            else {
                _dbSet.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public virtual TDomain Find(params object[] keyValues) {
            return _dbSet.Find(keyValues);
        }
    }
}

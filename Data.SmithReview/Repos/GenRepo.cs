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
    public class GenRepo<DomainContext, DomainType> : IGenRepo<DomainContext, DomainType>
            where DomainType : BaseDomainModel
            where DomainContext : IDbContext {
        public GenRepo(DomainContext context) {
            _context = context;
            _dbSet = context.Set<DomainType>();
        }

        protected DomainContext _context;
        protected DbSet<DomainType> _dbSet;
        protected IQueryable<DomainType> _query;
        public virtual GenRepo<DomainContext, DomainType> Include(params string[] includedProperties) {
            _query = _dbSet;
            foreach(string include in includedProperties) {
                _query = _query.Include(include);
            }
            return this;
        }

        public virtual IEnumerable<DomainType> Query(
                Expression<Func<DomainType, bool>> predicate = null,
                int page = 0,
                int perPage = 0,
                params string[] orderBy) {
            IQueryable<DomainType> query = _query ?? _dbSet;
            IQueryable<DomainType> orderedQuery = null;
            if (predicate != null) query = query.Where(predicate);
            
            if (orderBy != null) {
                foreach(string column in orderBy){
                    char firstChar = column.First();
                    string columnName = firstChar == '+' || firstChar == '-' ? column.Substring(1) : column;
                    Expression<Func<DomainType, object>> propertyExpression = (x)=> x.GetType().GetProperty(columnName).GetValue(x);
                    if (orderedQuery != null)
                        orderedQuery = firstChar == '-' ? orderedQuery.ThenByDescending(columnName) : orderedQuery.ThenBy(columnName);
                    else
                        orderedQuery = firstChar == '-' ?  query.OrderByDescending(columnName) : query.OrderBy(columnName);
                }
                query = orderedQuery;
            }
            if (page > 0 && perPage > 0)
                query
                    .Skip((page - 1) * perPage)
                    .Take(perPage);
            return query.ToList();
        }

        public virtual void Upsert(DomainType item) {
            if (item.HasEmptyId()) {
                _dbSet.Add(item);
            }
            else {
                _dbSet.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public virtual DomainType Find(params object[] keyValues) {
            return _dbSet.Find(keyValues);
        }
    }
}

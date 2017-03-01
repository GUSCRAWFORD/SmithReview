using Data.SmithReview.Domain;
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

        public virtual IEnumerable<DomainType> Query(
                Expression<Func<DomainType, bool>> predicate = null,
                Func<IQueryable<DomainType>, IOrderedQueryable<DomainType>> orderBy = null,
                params string[] includedProperties) {
            IQueryable<DomainType> query = _dbSet;
            if (predicate != null) query = query.Where(predicate);
            foreach(string include in includedProperties) {
                query = query.Include(include);
            }
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
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

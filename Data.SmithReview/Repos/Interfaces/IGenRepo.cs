using Data.SmithReview.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmithReview.Repos.Interfaces {
    public interface IGenRepo<DomainContext, DomainType>
            where DomainType : BaseDomainModel
            where DomainContext : Domain.Interfaces.IDbContext {

        IEnumerable<DomainType> Query(
                Expression<Func<DomainType, bool>> predicate = null,
                Func<IQueryable<DomainType>, IOrderedQueryable<DomainType>> orderBy = null,
                params string[] includedProperties);
        void Upsert(DomainType item);
        DomainType Find(params object[] keyValues);
    }
}

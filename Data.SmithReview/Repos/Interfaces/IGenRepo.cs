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
        GenRepo<DomainContext, DomainType> Include(params string[] includedProperties);
        IEnumerable<DomainType> Query(
                Expression<Func<DomainType, bool>> predicate = null,
                int page = 0,
                int perPage = 0,
                params string[] orderBy);
        void Upsert(DomainType item);
        DomainType Find(params object[] keyValues);
    }
}

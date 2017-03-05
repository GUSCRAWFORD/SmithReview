using Data.SmithReview.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmithReview.Repos.Interfaces {
    public interface IGenRepo<TContext, TDomain>
            where TDomain : BaseDomainModel
            where TContext : Domain.Interfaces.IDbContext {

        GenRepo<TContext, TDomain> Include(params string[] includedProperties);
        GenRepo<TContext, TDomain> AsNoTracking();

        IEnumerable<TDomain> Query(
                Expression<Func<TDomain, bool>> predicate = null,
                int page = 0,
                int perPage = 0,
                Func<QueryDetails, object> getQueryResult = null,
                params string[] orderBy);

        void Upsert(TDomain item);

        TDomain Find(params object[] keyValues);

        IEnumerable<TResult> Query<TResult>(
                Expression<Func<TDomain, TResult>> select,
                Expression<Func<TDomain, bool>> predicate = null,
                int page = 0,
                int perPage = 0,
                Func<QueryDetails, object> getQueryDetails = null,
                params string[] orderBy);
    }
    public class QueryDetails {
        public int RecordsReturned { get; set; }
        public int OfTotalRecords { get; set; }
    }
}

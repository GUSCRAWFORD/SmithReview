using Data.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Operations.SmithReview.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.SmithReview {
    public abstract class Operations<TModel, TDomain, TKey> : IOperations<TModel, TDomain, TKey>
            where TModel : BaseBusinessModel
            where TDomain : BaseDomainModel
            where TKey : IComparable {
        public Operations(IDbContextProvider contextProvider) {
            _context = contextProvider.Instance();
        }
        protected IDbContext _context;

        protected abstract TModel ToModel(TDomain domain);
        protected abstract TDomain ToDomain(TModel model);
        public abstract TModel SingleByKey(TKey id);
        public abstract IEnumerable<TModel> All(int page, int perPage, params string[] orderBy);
        public abstract void Save(TModel item);

    }
}

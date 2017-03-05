using Data.SmithReview.Domain;
using Models.SmithReview;
using System;
using System.Collections.Generic;

namespace Operations.SmithReview.Interfaces {
    public interface IOperations<TModel, TDomain, TKey>
            where TModel : BaseBusinessModel
            where TDomain : BaseDomainModel
            where TKey : IComparable {

        TModel SingleByKey(TKey id);

        Page<TModel> All(int page, int perPage, params string[] orderBy);

        void Save(TModel item);
    }
}

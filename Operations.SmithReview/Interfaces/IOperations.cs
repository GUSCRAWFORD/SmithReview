using Models.SmithReview;
using System;
using System.Collections.Generic;

namespace Operations.SmithReview.Interfaces {
    public interface IOperations<ModelType, KeyType> : IDisposable
            where ModelType : BaseBusinessModel
            where KeyType : IComparable {
        ModelType SingleByKey(KeyType id);
        IEnumerable<ModelType> All(int page, int perPage, params string[] orderBy);
        void Save(ModelType item);
    }
}

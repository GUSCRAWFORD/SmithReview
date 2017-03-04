
using Models.SmithReview;
using Data.SmithReview.Domain;
using System.Collections.Generic;

namespace Operations.SmithReview.Interfaces
{
    public interface IReviewOperations : IOperations<ReviewModel, Review, int> {
        IEnumerable<ReviewModel> AllByItem(int item, int page, int perPage, params string[] orderBy);
    }
}

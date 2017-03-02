using Operations.SmithReview.Interfaces;
using System;
using Data.SmithReview.Repos;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Repos.Interfaces;

namespace Operations.SmithReview.Interfaces
{
    public interface IReviewOperations : IOperations<ReviewModel, Review, int> {
    }
}

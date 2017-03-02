using Operations.SmithReview.Interfaces;
using System;
using Data.SmithReview.Repos;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Repos.Interfaces;

namespace Operations.SmithReview.Interfaces
{
    public interface IItemOperations : IOperations<ItemModel, Item, int> {
        
    }
}

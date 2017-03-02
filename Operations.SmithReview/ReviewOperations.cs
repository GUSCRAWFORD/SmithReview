using Operations.SmithReview.Interfaces;
using System;
using Data.SmithReview.Repos;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Repos.Interfaces;
using System.Collections.Generic;
using Operations.SmithReview.Extensions;

namespace Operations.SmithReview
{
    public class ReviewOperations : Operations, IReviewOperations {
        public ReviewOperations(IDbContext unitOfWork, IGenRepo<IDbContext, Review> reviewRepo = null) :
                base(unitOfWork) {
            _reviewRepo = reviewRepo ?? new GenRepo<IDbContext, Review>(_context);

        }
        IGenRepo<IDbContext, Review> _reviewRepo;
        public virtual ReviewModel SingleByKey(int id) {
            return _reviewRepo.Find(id)
                .ToBusinessModel<ReviewModel, Review>();
        }
        public virtual IEnumerable<ReviewModel> All() {
            return _reviewRepo.Query().ToBusinessModel<ReviewModel, Review>();
        }

        public IEnumerable<ReviewModel> All(int page, int perPage, params string[] orderBy) {
            return _reviewRepo.Query(null, page, perPage, orderBy).ToBusinessModel<ReviewModel, Review>();
        }

        public void Save(ReviewModel review) {
            _reviewRepo.Upsert(new Review {
                Id = review.Id,
                Comment = review.Comment,
                Rating = review.Rating,
                Reviewing = review.Reviewing.Id
            });
        }
    }
}

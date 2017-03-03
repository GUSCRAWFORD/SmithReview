﻿using Operations.SmithReview.Interfaces;
using System;
using Data.SmithReview.Repos;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Repos.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Operations.SmithReview
{
    public class ReviewOperations : Operations<ReviewModel, Review, int>, IReviewOperations {
        public ReviewOperations(IDbContext unitOfWork, IGenRepo<IDbContext, Review> reviewRepo = null) :
                base(unitOfWork) {
            _reviewRepo = reviewRepo ?? new GenRepo<IDbContext, Review>(_context);

        }
        IGenRepo<IDbContext, Review> _reviewRepo;
        public override ReviewModel SingleByKey(int id) {
            return ToModel(_reviewRepo.Find(id));
        }
        public virtual IEnumerable<ReviewModel> All() {
            return _reviewRepo.Query().Select(x=>new ReviewModel {
                Id = x.Id,
                Rating = x.Rating,
                Reviewing = new ItemModel { Id = x.Reviewing },
                Comment = x.Comment
            });
        }

        public override IEnumerable<ReviewModel> All(int page, int perPage, params string[] orderBy) {
            return _reviewRepo.Query(null, page, perPage, orderBy).Select(x=>ToModel(x));
        }

        public override void Save(ReviewModel review) {
            _reviewRepo.Upsert(new Review {
                Id = review.Id,
                Comment = review.Comment,
                Rating = review.Rating,
                Reviewing = review.Reviewing.Id
            });
        }

        protected override ReviewModel ToModel(Review domain) {
            return new ReviewModel {
                Id = domain.Id,
                Rating = domain.Rating,
                Reviewing = new ItemModel { Id = domain.Reviewing },
                Comment = domain.Comment
            };
        }
        protected override Review ToDomain(ReviewModel model) {
            return new Review {
                    Id = model.Id
                };
        }
    }
}

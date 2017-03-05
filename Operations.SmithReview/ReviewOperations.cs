using Operations.SmithReview.Interfaces;
using Data.SmithReview.Repos;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Repos.Interfaces;
using System.Linq;
using System;

namespace Operations.SmithReview
{
    public class ReviewOperations : Operations<ReviewModel, Review, int>, IReviewOperations {
        public ReviewOperations(IDbContext context, IGenRepo<IDbContext, Review> reviewRepo = null) :
                base(context) {
            _reviewRepo = reviewRepo ?? new GenRepo<IDbContext, Review>(context);
        }
        IGenRepo<IDbContext, Review> _reviewRepo;
        public override ReviewModel SingleByKey(int id) {
            return ToModel(_reviewRepo.Find(id));
        }

        public override Page<ReviewModel> All(int page, int perPage, params string[] orderBy) {
            QueryDetails details = null;
            return new Page<ReviewModel> {
                Collection = _reviewRepo.Query(null, page, perPage, (r)=>details=r, orderBy).Select(x=>ToModel(x)),
                OfTotal = details.OfTotalRecords
            };
        }

        public override void Save(ReviewModel review) {
            _reviewRepo.Upsert(ToDomain(review));
            _context.SaveChanges();
        }

        protected override ReviewModel ToModel(Review domain) {
            return new ReviewModel {
                Id = domain.Id,
                Rating = domain.Rating,
                Reviewing = new ItemModel { Id = domain.Reviewing },
                Comment = domain.Comment,
                Date = domain.Date
            };
        }
        protected override Review ToDomain(ReviewModel model) {
            return new Review {
                Comment = model.Comment,
                Rating = model.Rating,
                Reviewing = model.Reviewing.Id,
                Date = DateTime.Now.ToUniversalTime()
            };
        }

        public Page<ReviewModel> AllByItem(int item, int page, int perPage, params string[] orderBy) {
            QueryDetails details = null;
            return new Page<ReviewModel> {
                Collection = _reviewRepo.Query(review=>review.Reviewing == item, page, perPage, (r)=>details = r, orderBy).Select(x=>ToModel(x)),
                OfTotal = details.OfTotalRecords
            };
        }
    }
}

using Operations.SmithReview.Interfaces;
using Data.SmithReview.Repos;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Repos.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Operations.SmithReview
{
    public class ItemOperations : Operations<ItemModel, ReviewableItem, int>, IItemOperations {
        public ItemOperations(IDbContext context, IGenRepo<IDbContext, ReviewableItem> itemsRepo = null) :
                base (context) {
            _context = context;
            _itemsRepo = itemsRepo ?? new GenRepo<IDbContext, ReviewableItem>(context);
        }

        IGenRepo<IDbContext, ReviewableItem> _itemsRepo;

        public override ItemModel SingleByKey(int id) {
            var analyzedItemsRepo = new GenRepo<IDbContext, AnalyzedItem>(_context);
            return ToModel(analyzedItemsRepo.Find(id));
        }

        public override Page<ItemModel> All(int page, int perPage, params string[] orderBy) {
            var analyzedItemsRepo = new GenRepo<IDbContext, AnalyzedItem>(_context);
            QueryDetails r = null;
            return new Page<ItemModel> {
                Collection = analyzedItemsRepo.Query(null, page, perPage, (x)=>r = x,orderBy).Select(x=>ToModel(x)),
                OfTotal = r.OfTotalRecords
            };
        }

        public override void Save(ItemModel item) {
            _itemsRepo.Upsert(new ReviewableItem {
                Id = item.Id,
                Name = item.Name,
                Icon = item.Icon
            });
            _context.SaveChanges();
        }

        protected override ItemModel ToModel(ReviewableItem domain) {
            return new ItemModel {
                    Name = domain.Name,
                    Id = domain.Id,
                    Icon = domain.Icon
                };
        }
        protected virtual ItemModel ToModel(AnalyzedItem domain) {
            return new ItemModel {
                    Name = domain.Name,
                    Id = domain.Id,
                    Icon = domain.Icon,
                    AverageRating = domain.AverageRating ?? 0,
                    LowestRating = domain.LowestRating ?? 0,
                    HighestRating = domain.HighestRating ?? 0,
                    ReviewCount = domain.ReviewCount ?? 0,
                    Date = domain.Date,
                    Popularity = domain.Popularity ?? 0
                };
        }

        protected override ReviewableItem ToDomain(ItemModel model) {
            return new ReviewableItem {
                    Name = model.Name,
                    Id = model.Id
                };
        }
    }
}

using Operations.SmithReview.Interfaces;
using System;
using Data.SmithReview.Repos;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Repos.Interfaces;
using System.Collections.Generic;
using Data.SmithReview;
using System.Linq;

namespace Operations.SmithReview
{
    public class ItemOperations : Operations<ItemModel, Item, int>, IItemOperations {
        public ItemOperations(IDbContext unitOfWork = null, IGenRepo<IDbContext, Item> itemsRepo = null) :
                base (unitOfWork) {
            _itemsRepo = itemsRepo ?? new GenRepo<IDbContext, Item>(_context);
        }
        IGenRepo<IDbContext, Item> _itemsRepo;
        public override ItemModel SingleByKey(int id) {
            return ToModel(_itemsRepo.Find(id));
        }

        public override IEnumerable<ItemModel> All(int page, int perPage, params string[] orderBy) {
            return _itemsRepo.Include("Reviews").Query(null, page, perPage, orderBy).Select((x)=> ToModel(x));
        }

        public override void Save(ItemModel item) {
            _itemsRepo.Upsert(new Item {
                Id = item.Id,
                Name = item.Name,
                Icon = item.Icon
            });
            _context.SaveChanges();
        }

        protected override ItemModel ToModel(Item domain) {
            return new ItemModel {
                    Name = domain.Name,
                    Id = domain.Id,
                    AverageRating = domain.Reviews.Count()>0?domain.Reviews.Average(y=>y.Rating):0,
                    Lowest = domain.Reviews.Count()>0?domain.Reviews.Min(y=>y.Rating):0,
                    Highest = domain.Reviews.Count()>0?domain.Reviews.Max(y=>y.Rating):0,
                    SampleSize = domain.Reviews.Count
                };
        }
        protected override Item ToDomain(ItemModel model) {
            return new Item {
                    Name = model.Name,
                    Id = model.Id
                };
        }
    }
}

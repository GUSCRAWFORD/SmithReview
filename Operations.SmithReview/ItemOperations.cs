using Operations.SmithReview.Interfaces;
using System;
using Data.SmithReview.Repos;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Repos.Interfaces;
using System.Collections.Generic;
using Data.SmithReview;
using Operations.SmithReview.Extensions;

namespace Operations.SmithReview
{
    public class ItemOperations : Operations, IItemOperations {
        public ItemOperations(IDbContext unitOfWork = null, IGenRepo<IDbContext, Item> itemsRepo = null) :
                base (unitOfWork) {
            _itemsRepo = itemsRepo ?? new GenRepo<IDbContext, Item>(_context);
        }
        IGenRepo<IDbContext, Item> _itemsRepo;
        public virtual ItemModel SingleByKey(int id) {
            return _itemsRepo.Find(id)
                .ToBusinessModel<ItemModel, Item>();
        }

        public virtual IEnumerable<ItemModel> All(int page, int perPage, params string[] orderBy) {
            return _itemsRepo.Query(null, page, perPage, orderBy)
                .ToBusinessModel(
                    (x)=>new ItemModel {
                        Id = x.Id,
                        Name = x.Name
                    });
        }

        public virtual void Save(ItemModel item) {
            _itemsRepo.Upsert(new Item {
                Id = item.Id,
                Name = item.Name,
                Icon = item.Icon
            });
            _context.SaveChanges();
        }
    }
}

using Data.SmithReview.Domain.Interfaces;

using Operations.SmithReview.Interfaces;
using Operations.SmithReview;

using System.Collections.Generic;
using System.Web.Http;
using Models.SmithReview;
using Data.SmithReview;

namespace Api.SmithReview.Controllers
{
    public class ItemsController : SmithReviewController
    {
        private IItemOperations _itemOperations;
        public ItemsController() {
            _itemOperations = new ItemOperations();
        }
        ~ItemsController() {
            _itemOperations.Dispose();
        }
        // GET: api/Items
        public IEnumerable<ItemModel> Get(int page = 0, int perPage = 0, string orderBy = "")
        {
            return _itemOperations.All(page, perPage, orderBy.Split(','));
        }

        // GET: api/Items/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Items
        public void Post([FromBody]ItemModel item)
        {
            _itemOperations.Save(item);
        }

        // PUT: api/Items/5
        public void Put(int id, [FromBody]ItemModel item)
        {
            Post(item);
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {
        }
    }
}

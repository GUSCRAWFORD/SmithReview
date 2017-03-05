using Operations.SmithReview.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using Models.SmithReview;
using System.Web.Http.Cors;
using Microsoft.Practices.ServiceLocation;
using Operations.SmithReview;

namespace Api.SmithReview.Controllers
{
    [EnableCors(origins: "http://localhost:53180", headers: "*", methods: "*")]
    public class ItemsController : SmithReviewController
    {
        private IItemOperations _itemOperations;
        
        // GET: api/Items
        public Page<ItemModel> Get(int page = 0, int perPage = 0, string orderBy = "")
        {
            using(var context = _contextProvider.Instance()) {
                _itemOperations = new ItemOperations(context);
                return _itemOperations.All(page, perPage, orderBy.Split(','));
            }
        }

        // GET: api/Items/5
        public ItemModel Get(int id)
        {
            using(var context = _contextProvider.Instance()) {
                _itemOperations = new ItemOperations(context);
                return _itemOperations.SingleByKey(id);
            }
        }

        // POST: api/Items
        public void Post([FromBody]ItemModel item)
        {
            using(var context = _contextProvider.Instance()) {
                _itemOperations = new ItemOperations(context);
                _itemOperations.Save(item);
            }
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

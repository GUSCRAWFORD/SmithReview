using Operations.SmithReview.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using Models.SmithReview;
using System.Web.Http.Cors;
using Microsoft.Practices.ServiceLocation;

namespace Api.SmithReview.Controllers
{
    [EnableCors(origins: "http://localhost:53180", headers: "*", methods: "*")]
    public class ItemsController : SmithReviewController
    {
        private IItemOperations _itemOperations;
        public ItemsController() {
            _itemOperations = ServiceLocator.Current.GetInstance<IItemOperations>("IItemOperations");
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

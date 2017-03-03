using Operations.SmithReview.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using Models.SmithReview;
using System.Web.Http.Cors;
using Microsoft.Practices.ServiceLocation;

namespace Api.SmithReview.Controllers
{
    [EnableCors(origins: "http://localhost:53180", headers: "*", methods: "*")]
    public class ReviewsController : SmithReviewController
    {
        private IReviewOperations _reviewOperations;
        public ReviewsController() {
            _reviewOperations = ServiceLocator.Current.GetInstance<IReviewOperations>("IReviewOperations");
        }
        ~ReviewsController() {
            _reviewOperations.Dispose();
        }
        // GET: api/Items
        public IEnumerable<ReviewModel> Get(int page = 0, int perPage = 0, string orderBy = "")
        {
            return _reviewOperations.All(page, perPage, orderBy.Split(','));
        }

        // GET: api/Items/5
        public ReviewModel Get(int id)
        {
            return _reviewOperations.SingleByKey(id);
        }

        // POST: api/Items
        public void Post([FromBody]ReviewModel item)
        {
            _reviewOperations.Save(item);
        }

        // PUT: api/Items/5
        public void Put(int id, [FromBody]ReviewModel item)
        {
            Post(item);
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {
        }
    }
}

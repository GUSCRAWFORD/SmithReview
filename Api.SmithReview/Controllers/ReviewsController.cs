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
    public class ReviewsController : SmithReviewController
    {

        private IReviewOperations _reviewOperations;
        // GET: api/Items
        public Page<ReviewModel> Get(int item, int page = 0, int perPage = 0, string orderBy = "")
        {
            using(var context = _contextProvider.Instance()) {
                _reviewOperations = new ReviewOperations(context);
                return _reviewOperations.AllByItem(item, page, perPage, orderBy.Split(','));
            }
        }

        // GET: api/Items/5
        public ReviewModel Get(int id)
        {
            using(var context = _contextProvider.Instance()) {
                _reviewOperations = new ReviewOperations(context);
                return _reviewOperations.SingleByKey(id);
            }
        }

        // POST: api/Items
        public void Post([FromBody]ReviewModel item)
        {
            using(var context = _contextProvider.Instance()) {
                _reviewOperations = new ReviewOperations(context);
                _reviewOperations.Save(item);
            }
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

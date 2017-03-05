using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.ServiceLocation;
using Data.SmithReview.Domain.Interfaces;

namespace Api.SmithReview.Controllers {
    public abstract class SmithReviewController : ApiController {
        protected IDbContextProvider _contextProvider;
        public SmithReviewController() {
            _contextProvider = ServiceLocator.Current.GetInstance<IDbContextProvider>("IDbContextProvider");
        }

    }

}
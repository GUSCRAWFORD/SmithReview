using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity.Configuration;

namespace Api.SmithReview.Controllers {
    public abstract class SmithReviewController : ApiController {
        public SmithReviewController() {
            UnityServiceLocator locator = new UnityServiceLocator(CreateConfiguredUnityContainer());
            ServiceLocator.SetLocatorProvider(()=>locator);
        }
        protected static IUnityContainer CreateConfiguredUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            // (optional) load static config from the *.xml file
            container.LoadConfiguration();
 
            return container;
        }
    }

}
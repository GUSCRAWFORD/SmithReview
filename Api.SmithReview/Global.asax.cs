using Data.SmithReview.Domain.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Http;

namespace Api.SmithReview
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityServiceLocator locator = new UnityServiceLocator(CreateConfiguredUnityContainer());
            ServiceLocator.SetLocatorProvider(()=>locator);
        }
        public override void Dispose() {
            ServiceLocator.Current.GetInstance<IDbContextProvider>("IDbContextProvider").Dispose();
            base.Dispose();
        }
        public static IUnityContainer CreateConfiguredUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.LoadConfiguration();
 
            return container;
        }
    }
}

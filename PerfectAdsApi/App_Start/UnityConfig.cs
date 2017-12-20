using MongoDB.Driver;
using PerfectAdsApi.Repository;
using System.Configuration;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace PerfectAdsApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            var connectionString = ConfigurationManager.ConnectionStrings["mongoConnectionString"].ConnectionString;
            container.RegisterSingleton<IMongoClient, MongoClient>(new InjectionConstructor(connectionString));
            container.RegisterType<IAccountRepository, AccountRepository>();
        }
    }
}
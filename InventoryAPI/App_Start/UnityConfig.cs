using System.Web.Http;
using Unity;
using Unity.WebApi;
using Inventory.IService;
using Inventory.Service;


namespace InventoryAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProduct, ProductService>();
            container.RegisterType<ISupplier, SupplierService>();
            container.RegisterType<IUser, UserService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
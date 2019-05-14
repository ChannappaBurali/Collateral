using System.Linq;
using System.Web.Http;
using Inventory.IService;
using Inventory.Model;

namespace InventoryAPI.Controllers
{
   // [Authorize]
    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiController
    {
        private readonly ISupplier _iSupplier = null;
        public SupplierController(ISupplier iSupplier)
        {
            _iSupplier = iSupplier;
        }
        /// <summary>
        /// To Get List of Products 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getsuppliers")]
        public IQueryable<SupplierModel> GetSuppliers()
        {
            return _iSupplier.GetSuppliers();
        }
    }
}

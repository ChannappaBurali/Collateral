using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.IService;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.Service
{
   public class SupplierService:ISupplier
    {
        public InventoryEntities _entity = null;
        public SupplierService()
        {
            _entity = new InventoryEntities();
        }
        public IQueryable<SupplierModel> GetSuppliers()
        {
            List<SupplierModel> supplierList = new List<SupplierModel>();
            var details = _entity.Suppliers;
            if (details != null)
            {
                Parallel.ForEach(details, x =>
                {
                    SupplierModel obj = new SupplierModel();
                    obj.SupplierID = x.SupplierID;
                    obj.SuppierName = x.SuppierName;
                    supplierList.Add(obj);

                });
                return supplierList.AsQueryable();
            }
            else
            {
                return supplierList.AsQueryable();
            }
        }
        public static SupplierModel MapToSupplierModel(Supplier entity)
        {
            var supplier = new SupplierModel();
            supplier.SupplierID = entity.SupplierID;
            supplier.SuppierName = entity.SuppierName;
            supplier.Address = entity.Address;
            supplier.PhoneNo = entity.PhoneNo;
            return supplier;
        }
    }
}

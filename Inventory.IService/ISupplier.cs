using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;

namespace Inventory.IService
{
    public interface ISupplier
    {
        IQueryable<SupplierModel> GetSuppliers();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;

namespace Inventory.IService
{
    public interface IProduct
    {
        IQueryable<ProductModel> GetProducts();
        ProductModel GetProductById(int productId);
        void PutProduct(ProductModel product);
        void PostProduct(ProductModel product);
        bool IsProductExists(int productId);
        bool CheckProductNameExists(string product, int productId);
        //decimal GetTotalProductsCost();
    }
}

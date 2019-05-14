using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.IService;
using Inventory.Model;
using Inventory.DAL;
using System.Data.Entity;

namespace Inventory.Service
{
    public class ProductService : IProduct
    {
        public InventoryEntities _entity = null;
        public ProductService()
        {
            _entity = new InventoryEntities();
        }

        public IQueryable<ProductModel> GetProducts()
        {
            List<ProductModel> productList = new List<ProductModel>();
            var details = _entity.Products;
            //details = from p in _entity.Products
            //          join s in _entity.Suppliers on p.SupplierID equals s.SupplierID
            //          select p.ProductID
            if (details != null)
            {
                Parallel.ForEach(details, x =>
                {
                    ProductModel obj = new ProductModel();
                    obj.ProductID = x.ProductID;
                    obj.ProductName = x.ProductName;
                    obj.Quantity = x.Quantity;
                    obj.SupplierID = x.SupplierID;
                    obj.UnitPrice = x.UnitPrice;
                    obj.TotalCost = x.Quantity * Convert.ToDecimal(x.UnitPrice);
                    productList.Add(obj);

                });
                return productList.AsQueryable();
            }
            else
            {
                return productList.AsQueryable();
            }
        }

        public ProductModel GetProductById(int productId)
        {
            var productEntity = _entity.Products.FirstOrDefault(a => a.ProductID == productId);
            if (productEntity == null)
            {
                return null;
            }
            ProductModel productModel = new ProductModel();
            productModel.ProductID = productEntity.ProductID;
            productModel.ProductName = productEntity.ProductName;
            productModel.Quantity = productEntity.Quantity;
            productModel.SupplierID = productEntity.SupplierID;
            productModel.UnitPrice = productEntity.UnitPrice;
            return productModel;
        }

        public bool IsProductExists(int productId)
        {
            return _entity.Products.Count(e => e.ProductID == productId) > 0;
        }

        public void PostProduct(ProductModel productModel)
        {
            Product productEntity = new Product();
            productEntity.ProductID = productModel.ProductID;
            productEntity.ProductName = productModel.ProductName;
            productEntity.Quantity = productModel.Quantity;
            productEntity.SupplierID = productModel.SupplierID;
            productEntity.UnitPrice = productModel.UnitPrice;
            _entity.Products.Add(productEntity);
            _entity.SaveChanges();
        }

        public void PutProduct(ProductModel productModel)
        {
            Product productEntity = new Product();
            productEntity.ProductID = productModel.ProductID;
            productEntity.ProductName = productModel.ProductName;
            productEntity.Quantity = productModel.Quantity;
            productEntity.SupplierID = productModel.SupplierID;
            productEntity.UnitPrice = productModel.UnitPrice;
            _entity.Entry(productEntity).State = EntityState.Modified;
            try
            {
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
        public bool CheckProductNameExists(string product, int productId)
        {
            if (productId == 0)
            {
                return _entity.Products.FirstOrDefault(a => a.ProductName == product) != null ? true : false;
            }
            return _entity.Products.FirstOrDefault(a => a.ProductName == product && a.ProductID != productId) != null ? true : false;
        }

        //public decimal GetTotalProductsCost()
        //{
        //    decimal totalCost = 0;
        //    _entity.Products.ToList().ForEach(a => { totalCost = totalCost + Convert.ToDecimal(a.TotalCost); });
        //    return totalCost;
        //}
        public static Product MapToProductEntity(ProductModel model)
        {
            var inventory = new Product();
            inventory.ProductID = model.ProductID;
            inventory.ProductName = model.ProductName;
            inventory.SupplierID = model.SupplierID;
            inventory.Quantity = model.Quantity;
            inventory.UnitPrice = model.UnitPrice;
            //inventory.TotalCost = model.TotalCost;

            return inventory;
        }
        //public static ProductModel MapToProductModel(ProductDetail entity)
        //{
        //    var inventory = new Models.DTOS.ProductDTO();
        //    inventory.ProductId = entity.ProductId;
        //    inventory.Supplier = entity.Supplier;
        //    inventory.ProductName = entity.ProductName;
        //    inventory.Quantity = entity.Quantity;
        //    inventory.UnitPrice = entity.UnitPrice;
        //    inventory.TotalCost = entity.TotalCost;

        //    return inventory;
        //}

    }
}

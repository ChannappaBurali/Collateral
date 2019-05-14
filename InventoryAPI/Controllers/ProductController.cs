using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory.Model;
using Inventory.IService;
using System.Data.Entity.Infrastructure;

namespace InventoryAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProduct _iProduct = null;
        public ProductController(IProduct iProduct)
        {
            _iProduct = iProduct;
        }
        /// <summary>
        /// To Get List of Products 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getproducts")]
        public IQueryable<ProductModel> GetProducts()
        {
            return _iProduct.GetProducts();
        }

        /// <summary>
        /// To get a required product
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("productbyid/{productId}")]
        public IHttpActionResult GetProductById(int productId)
        {
            ProductModel productModel = _iProduct.GetProductById(productId);
            if (productModel == null)
                return NotFound();
            return Ok(productModel);
        }
        /// <summary>
        /// To Save New Product Details
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("saveProduct")]
        public IHttpActionResult PostProduct(ProductModel product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _iProduct.PostProduct(product);
            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        /// <summary>
        /// To update product details
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateProduct")]
        public IHttpActionResult PutProduct([FromBody]ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _iProduct.PutProduct(product);
                return Ok(new { IsProductUpdated = true });
            }
            catch (DbUpdateConcurrencyException exception)
            {
                if (!_iProduct.IsProductExists(product.ProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpGet]
        [Route("GetCollaterals/{accountNumber}")]
        public IHttpActionResult GetCollaterals(int accountNumber)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
               
                return NotFound();
            }
        }
    }
}

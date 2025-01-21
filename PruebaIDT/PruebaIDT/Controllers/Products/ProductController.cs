using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaIDT.Domains.Product;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController(IProductDomain productDomain) : ControllerBase
    {
        #region Gets
        [HttpGet]
        public async Task<IActionResult> ObtainProducts()
        {
            var response = await productDomain.ObtainProducts();
            return StatusCode(response.Code.GetHashCode(), response.Data);
        }
        #endregion

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductoModel productoModel)
        {
            var response = await productDomain.UpdateProduct(productoModel);
            return StatusCode(response.Code.GetHashCode(), response.Data);
        }
    }
}

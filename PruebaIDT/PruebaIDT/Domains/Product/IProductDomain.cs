using PruebaIDT.Models.DTOs.Universal;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Domains.Product
{
    public interface IProductDomain
    {
        Task<UniversalResponseDto<object>> ObtainProducts();
        Task<UniversalResponseDto<ProductoModel>> UpdateProduct(ProductoModel productoModel);
    }
}

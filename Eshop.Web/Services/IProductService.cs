using Eshop.Model;
using System.Runtime.InteropServices;

namespace Eshop.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListDTO>?> GetProductList();
        Task<IEnumerable<ProductListDTO>?> GetProductList(string valStr, [Optional] string typeStr);
        Task<Product?> GetProduct(int id);
    }
}

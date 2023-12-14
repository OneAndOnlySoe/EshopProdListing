using Eshop.Model;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace Eshop.Web.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductService> _logger;
        
        public ProductService(HttpClient httpClient, ILogger<ProductService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Product?> GetProduct(int id)
        {
            try
            {
                var  product = await _httpClient.GetFromJsonAsync<Product>($"api/product/{id}");
                return product;
            }
            catch (HttpRequestException e)
            {
                _logger.LogDebug("HttpRequestException raise to GetProductById : {e.Message} - {e.StatusCode}", e.Message, e.StatusCode);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogDebug("Exception raise to GetProductById : {e.Message}", e.Message);
                throw;
            }
        }
    
        public async Task<IEnumerable<ProductListDTO>?> GetProductList()
        {   
            try
            {
                var products = await this._httpClient.GetFromJsonAsync<IEnumerable<ProductListDTO>>("api/product");
                return products;
            }
            catch (HttpRequestException e)
            {
                _logger.LogDebug("HttpRequestException raise to GetProductList : {e.Message} - {e.StatusCode}", e.Message, e.StatusCode);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogDebug("Exception raised to GetProductList : {e.Message}", e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<ProductListDTO>?> GetProductList(string valStr, [Optional] string typeStr)
        {
            try
            {
                var products = await this._httpClient.GetFromJsonAsync<IEnumerable<ProductListDTO>>($"api/product/filter/{valStr}/{typeStr}");
                return products;
            }
            catch (HttpRequestException e)
            {
                _logger.LogDebug("HttpRequestException raised to GetProductListBySearchValue : {e.Message} - {e.StatusCode}", e.Message, e.StatusCode);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogDebug("Exception raised to GetProductListBySearchValue : {e.Message}", e.Message);
                throw;
            }
        }
    }
}

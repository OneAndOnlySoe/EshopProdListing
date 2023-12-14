using Eshop.Model;

namespace Eshop.Api.Mappers
{
    public static class DTOMapper
    {
        public static IEnumerable<ProductListDTO> ConvertToDTO(this IEnumerable<Product> products)
        {
            return products.Select(prod => new ProductListDTO
            {
                Id = prod.Id,
                Name = prod.Name,
                Price = prod.Price,
                ThumbnailURL = prod.ThumbnailURL,
                IsNewArriavl = prod.IsNewArriavl
            });
        }
    }
}

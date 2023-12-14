using Eshop.Api.Mappers;
using Eshop.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static readonly ImmutableList<Product> Products = ImmutableList.CreateRange(new List<Product>()
        {
            new()
            {
                Id = 1,
                Name = "Barbie™ Flared Trouser",
                Price = 49.90m,
                Description = "Low rise pants made of metallic denim. Five pockets. Front zip and metal button closure. Special collection x Barbie™",
                ThumbnailURL = "https://placehold.co/550x750?text=Flared+Trouser",
                ImageURL = "https://placehold.co/569x526?text=Barbie+Flared+Trouser",
                Quantity = 3,
                Size ="S,M",
                Color ="Pink",
                Category = "Trousers",
                Manufacturer = "Zara",
                IsNewArriavl = false
            },
            new()
            {
                Id = 2,
                Name = "Jenny Cargo Jean",
                Price = 56.00m,
                Description = "We are a proud member of Better Cotton. By buying cotton products from us, you are supporting more sustainable cotton farming. This product is sourced via mass balance with no Better Cotton.",
                ThumbnailURL = "https://placehold.co/550x750?text=Jny+Cargo+Jean",
                ImageURL = "https://placehold.co/569x526?text=Jenny+Cargo+Jean",
                Quantity = 6,
                Size ="S,M,L,XL",
                Color ="Dark Wash",
                Category = "Jeans",
                Manufacturer = "Forever",
                IsNewArriavl = false
            },
            new()
            {
                Id = 3,
                Name = "Junior Print Tee",
                Price = 24.00m,
                Description = "Due to different fabric properties, washing, finishing or other factors, the actual measurements of the item may vary from the size chart up to 1 inch.",
                ThumbnailURL = "https://placehold.co/550x750?text=Junr+Print+Tee",
                ImageURL = "https://placehold.co/569x526?text=Junior+Print+Tee",
                Quantity = 6,
                Size ="S,M,L,XL",
                Color ="Blue Dip Dyed",
                Category = "Kitwears",
                Manufacturer = "Giordano",
                IsNewArriavl = false
            },
            new()
            {
                Id = 4,
                Name = "Rhinestone Flower Brooch",
                Price = 19.90m,
                Description = "Made of silver tone pot metal, this brooch is shaped like an orchid, with part of the blossom on a spring.",
                ThumbnailURL = "https://placehold.co/550x750?text=Flower+Brooch",
                ImageURL = "https://placehold.co/569x526?text=Rhinestone+Flower+Brooch",
                Quantity = 12,
                Size ="15cm x 30cm",
                Color ="Dark Silver",
                Category = "Accessories",
                Manufacturer = "Zara",
                IsNewArriavl = true
            },
            new()
            {
                Id = 5,
                Name = "Ecko Rhino Hoodie",
                Price = 40.60m,
                Description = "Merchandises are offered in our stores or on macys.com at those prices. So, the savings we show from these prices may not be based on actual sales of the items. Limited quantities, while supplies last.",
                ThumbnailURL = "https://placehold.co/550x750?text=Rhinoo+Hoodie",
                ImageURL = "https://placehold.co/569x526?text=Ecko+Rhino+Hoodie",
                Quantity = 23,
                Size ="S,M,L,XL,2XL",
                Color ="Red Marled",
                Category = "Sweatshirts",
                Manufacturer = "Ecko United",
                IsNewArriavl = false
            },
            new()
            {
                Id = 6,
                Name = "YPB Aspen Parka",
                Price = 350.00m,
                Description = "New active parka in a wind- and water-resistant satin fabric, removable hood with storm collar, YPB logo patch at sleeve, djustable belt at waist, cozy-lined front pockets with flap closure. Imported.",
                ThumbnailURL = "https://placehold.co/550x750?text=Yp+Aspen+Parka",
                ImageURL = "https://placehold.co/569x526?text=YPB+Aspen+Parka",
                Quantity = 7,
                Size ="XS,S,M,L",
                Color ="Onyx",
                Category = "Jacket",
                Manufacturer = "Abercrombie",
                IsNewArriavl = true
            }
        });

        // GET: api/<ProductController>
        [HttpGet]
        [ProducesResponseType(typeof(Product[]),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get()
        {
            var productList = Products.ConvertToDTO();
            return productList is null ? NotFound() : Ok(productList.OrderBy(prod => prod.Name));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = Products.FirstOrDefault(prod => prod.Id == id);
            return product is null ? NotFound() : Ok(product);
        }

        // GET api/<ProductController>/jeans/zara
        [HttpGet("filter/{searchVal}/{searchType?}")]
        public IActionResult Get(string searchVal, string? searchType = "all")
        {
            if (searchType is "all")
            {
                Func<string, bool> isValidSearch = str => str != null && str.ToUpper().Contains(searchVal.ToUpper());
                var productList = Products.Where
                    (prod => isValidSearch(prod.Name) ||
                        isValidSearch(prod.Description) ||
                        isValidSearch(prod.Size) ||
                        isValidSearch(prod.Color) ||
                        isValidSearch(prod.Category) ||
                        isValidSearch(prod.Manufacturer)
                ).ToList();
                return productList is null ? NotFound() : Ok(productList);
            }
            else if ("category".Equals(searchType, StringComparison.OrdinalIgnoreCase))
            {
                var productList = Products.Where(prod => string.Equals(prod.Category, searchVal, StringComparison.OrdinalIgnoreCase)).ToList();
                return productList is null ? NotFound() : Ok(productList);
            }
            else if ("manufacturer".Equals(searchType, StringComparison.OrdinalIgnoreCase))
            {
                var productList = Products.Where(prod => string.Equals(prod.Manufacturer, searchVal, StringComparison.OrdinalIgnoreCase)).ToList();
                return productList is null ? NotFound() : Ok(productList);
            }
           return NotFound();
        }
    }
}

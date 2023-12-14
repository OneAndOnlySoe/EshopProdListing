using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Model
{
    public class ProductListDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? ThumbnailURL { get; set; }
        public bool IsNewArriavl { get; set; }
    }
}

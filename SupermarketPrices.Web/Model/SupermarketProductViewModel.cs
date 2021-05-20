using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketPrices.Web.Model
{
    public class SupermarketProductViewModel
    {
        public int SupermarketId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public ProductViewModel Product { get; set; }
    }
}

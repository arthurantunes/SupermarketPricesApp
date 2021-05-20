using System.Collections.Generic;

namespace SupermarketPrices.Api.Models
{
    public class ProductSupermarketPriceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EAN { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public List<SupermarketPriceViewModel> Prices { get; set; }

    }

}


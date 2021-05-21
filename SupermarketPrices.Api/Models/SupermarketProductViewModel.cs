using System;

namespace SupermarketPrices.Api.Models
{
    public class SupermarketProductViewModel
    {
        public int SupermarketId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public ProductViewModel Product { get; set; }
    }
}

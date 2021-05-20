using System;

namespace SupermarketPrices.Domain.Entities
{
    public class SupermarketProduct : Entity
    {
        public SupermarketProduct(int supermarketId, int productId, DateTime date, decimal price)
        {
            SupermarketId = supermarketId;
            ProductId = productId;
            Date = date;
            Price = price;
        }

        public int SupermarketId { get; private set; }
        public int ProductId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Price { get; private set; }

    }
}

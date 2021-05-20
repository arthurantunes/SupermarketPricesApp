using System.Collections.Generic;

namespace SupermarketPrices.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, string description, string eAN, string sKU, string brand)
        {
            Name = name;
            Description = description;
            EAN = eAN;
            SKU = sKU;
            Brand = brand;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string EAN { get; private set; }
        public string SKU { get; private set; }
        public string Brand { get; private set; }

        public List<SupermarketProduct> SupermarketProduct { get; set; }


    }
}

using System.Collections.Generic;

namespace SupermarketPrices.Domain.Entities
{
    public class Supermarket : Entity
    {
        public Supermarket(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public List<SupermarketProduct> SupermarketProduct { get; set; }
    }
}

using System.Collections.Generic;

namespace SupermarketPrices.Api.Models
{
    public class SupermarketViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SupermarketProductViewModel> Products { get; set; }
    }

}


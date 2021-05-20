using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketPrices.Web.Model
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string EAN { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
    }
}

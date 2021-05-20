using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketPrices.Web.Model
{
    public class SupermarketViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field Name is required!")]
        public string Name { get; set; }

        public List<SupermarketProductViewModel> Products { get; set; }


    }
}

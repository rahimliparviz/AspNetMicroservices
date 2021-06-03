using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Aggregator.Models
{
    public class ShoppingDto
    {
        public string UserName { get; set; }
        public BasketDto BasketWithProducts { get; set; }
        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}

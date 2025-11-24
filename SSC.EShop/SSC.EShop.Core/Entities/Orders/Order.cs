using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.EShop.Core.Entities.Orders
{
    public class Order
    {
      
        public Guid Id { get; set; }

      
        public Guid UserId { get; set; }

        public DateTime DateOfArrive { get; set; }

        
        public List<OrderItem>? Items { get; set; }

    }
}

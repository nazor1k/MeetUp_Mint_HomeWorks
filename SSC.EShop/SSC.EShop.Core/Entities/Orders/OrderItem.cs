using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.EShop.Core.Entities.Orders
{
    public class OrderItem
    {
        
        public Guid Id { get; set; }

     
        public string Quantity { get; set; }
        



       
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }



       
        public Guid OrderId { get; set; }

        public Order? Order { get; set; }
    }
}

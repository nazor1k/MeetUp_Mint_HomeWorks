using SSC.EShop.Core.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.EShop.Core.Entities
{
    public class User
    {
       
        public Guid Id { get; set; }
        
        public string Login { get; set; }
       
        public string Password { get; set; }
        
        public string? FirstName { get; set; }

        public List<Order>? Orders { get; set; }




    }
}

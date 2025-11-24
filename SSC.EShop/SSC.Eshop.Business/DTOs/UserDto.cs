using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Eshop.Business.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
    }
}

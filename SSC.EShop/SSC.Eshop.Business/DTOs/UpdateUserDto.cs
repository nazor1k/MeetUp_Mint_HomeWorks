using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Eshop.Business.DTOs
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Login { get; set; }

        
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}

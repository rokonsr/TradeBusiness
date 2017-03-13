using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeBusiness.Models
{
    public class UserLogin
    {
        [Key]
        public int AdminUserId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "User Name Is Required")]

        [Display(Name = "Admin User name")]
        [StringLength(50, ErrorMessage = "Must be between 3 and 50 characters long !", MinimumLength = 3)]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter Valid User Name !")]
        public string AdminUsername { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Admin Password")]
        [StringLength(130, ErrorMessage = "Must be between 3 and 130 characters long !", MinimumLength = 3)]
        public string AdminPassword { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using TradeBusiness.Models;

namespace TradeBusiness.Areas.Admin.Models
{
    //created by ataur
    public class UserInfoPartial:CommonModel
    {
        [Key]
        public short UserId { get; set; }

        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Name Is Required !")]
        [StringLength(50, ErrorMessage = "Must be between 3 and 50 characters long !", MinimumLength = 3)]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter Valid User Name !")]
        public string Username { get; set; }

        public short BranchId { get; set; }


        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }
    }
}
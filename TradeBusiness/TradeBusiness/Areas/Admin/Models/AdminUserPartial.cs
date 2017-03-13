﻿using System.ComponentModel.DataAnnotations;
using TradeBusiness.Models;

namespace TradeBusiness.Areas.Admin.Models
{
    public class AdminUserPartial : CommonModel
    {
        [Key]
        public short AdminUserId { get; set; }

        //[Required]
        [Display(Name = "Username")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string AdminUsername { get; set; }


        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Password Is Required !")]
        //[StringLength(130, ErrorMessage = "Must be between 3 and 130 characters long !", MinimumLength = 3)]
        //[RegularExpression(@"^(?=.{3,})(?=.*?[A-Z])(?=.*?[a-z])(?=.*?\d).*$", ErrorMessage = "Enter at least 6 characters,1 uppercase,1 lowercase,1 number !")]
        //public string AdminPassword { get; set; }

        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Confirm Password Is Required !")]
        //[Display(Name = "Confirm Password")]
        //[Compare("AdminPassword", ErrorMessage = "Password and confirm password must be same!")]
        //public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "User Role")]
        public byte UserRole { get; set; }


        [Display(Name = "User Role")]
        public string UserRoleName { get; set; }


        [Required]
        [Display(Name = "Email")]
        [StringLength(99, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string EmailAddress { get; set; }


        [Required]
        [Display(Name = "Maximum Company")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Numbers Only.")]
        public byte MaxCompany { get; set; }


        [Required]
        [Display(Name = "Maximum Branch")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Numbers Only.")]
        public short MaxBranch { get; set; }
    }
}
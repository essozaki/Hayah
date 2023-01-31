using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Project.Models
{
    public class registerationVM
    {

        public int Id { get; set; }


        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage ="You must Enter Valid Email")]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public bool? Gender { get; set; }


        [Required(ErrorMessage ="Password required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage ="Min length 3")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min length 3")]
        [Compare("Password")]
        [Display(Name = "confirm Password")]
        public string confirmPassword { get; set; }
       

      


     
      
    }
}

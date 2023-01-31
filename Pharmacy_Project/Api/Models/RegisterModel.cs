using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Project.Api.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required, StringLength(128)]
        public string? Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool? Gender { get; set; }




    }
}

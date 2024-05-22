using System.ComponentModel.DataAnnotations;

namespace Lap3.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "The value \"{0}\" is invalid.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "The value \"{0}\" is invalid.")]
        [DataType(DataType.Time)]
        public DateTime BatchTime { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter website url")]
        [Url]
        public string WebsiteUrl { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Confirm password does not match.")]
        public string ConfirmPassword { get; set; }
    }

}

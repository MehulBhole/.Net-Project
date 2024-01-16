using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class OwnerData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Enter your name properly.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Invalid Mobile Number Format.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Mobile Number Format.")]
        public long PhoneNo { get; set; }

        [Required(ErrorMessage = "PAN Number is required.")]
        [RegularExpression(@"[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}", ErrorMessage = "Enter PAN Number properly.")]
        public string PanNumber { get; set; }

        public DateOnly DateOfBirth { get; set; }
        [Required(ErrorMessage = "City is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Enter your city properly.")]
        public string City { get; set; }

        [Required(ErrorMessage = "PIN Code is required.")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Enter 6-digit PIN Code only.")]
        public int PinCode { get; set; }

        public string OriginalUserId { get; set; }
        public string ImageFilePath { get; set; }

    }
}

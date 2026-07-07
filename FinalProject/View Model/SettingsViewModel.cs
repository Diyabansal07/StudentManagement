using System.ComponentModel.DataAnnotations;

namespace FinalProject.View_Model
{
    public class SettingsViewModel
    {
        //==============================
        // Editable Fields
        //==============================

        [Required(ErrorMessage = "Full Name is required.")]
        [Display(Name = "Full Name")]
        [StringLength(100)]
        public string? FullName { get; set; }


        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email Address.")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }


        [Phone(ErrorMessage = "Please enter a valid Phone Number.")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }


        //==============================
        // Read Only Information
        //==============================

        [Display(Name = "Username")]
        public string? UserName { get; set; }

        public string? UserId { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        // Optional (display later if needed)
        public DateTime? AccountCreatedOn { get; set; }
    }
}
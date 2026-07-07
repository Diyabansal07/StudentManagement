using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }


        [Required(ErrorMessage = "First Name Required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "LastName required.")]

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Gender required.")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email required.")]
        [MinLength(8, ErrorMessage = "length should be 8 characters")]
        [MaxLength(12)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber required.")]
        [MinLength(10, ErrorMessage = "length should be 10 digits")]
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string? Address { get; set; }

        public string? Department { get; set; }

        //public string? Course { get; set; }

        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }


        [NotMapped]
        public List<Course>? CourseList { get; set; }

        public string? Section { get; set; }

        public int? Semester { get; set; }

        public DateTime? AdmissionDate { get; set; } = DateTime.Now;

        public string? Status { get; set; }
    }
}


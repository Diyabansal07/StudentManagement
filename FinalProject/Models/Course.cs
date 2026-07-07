using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Code is required.")]
        [Display(Name = "Course Code")]
        [StringLength(10, ErrorMessage = "Maximum 10 characters allowed.")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course Name is required.")]
        [Display(Name = "Course Name")]
        [StringLength(100)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, 10, ErrorMessage = "Duration must be between 1 and 10 years.")]
        [Display(Name = "Duration (Years)")]
        public int DurationYears { get; set; }

        [Required(ErrorMessage = "Total semesters are required.")]
        [Range(1, 20)]
        [Display(Name = "Total Semesters")]
        public int TotalSemesters { get; set; }

        [Required(ErrorMessage = "Credits are required.")]
        [Range(1, 300)]
        [Display(Name = "Total Credits")]
        public int TotalCredits { get; set; }

        [Required(ErrorMessage = "Course Type is required.")]
        [Display(Name = "Course Type")]
        public string CourseType { get; set; }

        [Display(Name = "Description")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

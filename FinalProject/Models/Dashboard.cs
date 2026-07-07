namespace FinalProject.Models
{
    public class Dashboard
    {
        public int TotalStudents { get; set; }

        public int ActiveStudents { get; set; }

        public int TotalCourses { get; set; }

        public int ActiveCourses { get; set; }


        public List<Student> RecentStudents { get; set; } = new();
    }
}

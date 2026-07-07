using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

//namespace FinalProject.Controllers
//{
//    [Authorize]
//    public class DashboardController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
namespace FinalProject.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Dashboard vm = new Dashboard();

            // Total Students
            vm.TotalStudents = _context.Students.Count();

            // Active Students
            vm.ActiveStudents = _context.Students
                                        .Count(s => s.Status=="Active");

            // Total Courses
            vm.TotalCourses = _context.Courses.Count();

            // Active Courses
            vm.ActiveCourses = _context.Courses
                                       .Count(c => c.Status == "Active");

            // Latest 5 Students
            vm.RecentStudents = _context.Students
                               .Include(s => s.Course)
                               .OrderByDescending(s => s.AdmissionDate)
                               .Take(5)
                               .ToList();

            return View(vm);
        }
    }
}
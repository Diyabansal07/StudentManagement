//namespace FinalProject.Controllers
//{
//    public class CourseController
//    {
//    }
//}

using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }

        // ==========================
        // Display All Courses
        // ==========================

        public IActionResult Index()
        {
            var objCourseList = _db.Courses.ToList();
            return View(objCourseList);
        }

        // ==========================
        // Add / Edit Course
        // ==========================

        public IActionResult Upsert(int? id)
        {
            Course obj = new Course();

            if (id == null || id == 0)
            {
                return View(obj);
            }

            obj = _db.Courses.FirstOrDefault(x => x.CourseId == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // ==========================
        // Save Course
        // ==========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Course obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.CourseId == 0)
                {
                    obj.CreatedDate = DateTime.Now;

                    _db.Courses.Add(obj);
                }
                else
                {
                    _db.Courses.Update(obj);
                }

                _db.SaveChanges();

                TempData["success"] = "Course saved successfully.";

                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        // ==========================
        // Delete Course
        // ==========================

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var course = _db.Courses.FirstOrDefault(x => x.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // ==========================
        // Confirm Delete
        // ==========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Course obj)
        {
            var course = _db.Courses.Find(obj.CourseId);

            if (course == null)
            {
                return NotFound();
            }

            _db.Courses.Remove(course);

            _db.SaveChanges();

            TempData["success"] = "Course deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}

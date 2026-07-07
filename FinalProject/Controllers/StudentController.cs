using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
            return View(students);
        }

        //public IActionResult Upsert(int id)
        //{
        //    if (id == 0)
        //        return View(new Student());

        //    var student = _context.Students.Find(id);

        //    if (student == null)
        //        return NotFound();

        //    return View(student);
        //}
        public IActionResult Upsert(int? id)
        {
            Student obj = new Student();

            // Load all courses for the dropdown
            obj.CourseList = _context.Courses.ToList();

            if (id == null || id == 0)
            {
                return View(obj);
            }

            //edit
            obj = _context.Students.FirstOrDefault(x => x.StudentId == id);

            if (obj == null)
            {
                return NotFound();
            }

            // Load the course list again after fetching the student
            obj.CourseList = _context.Courses.ToList();

            return View(obj);
        }


        [HttpPost]
        public IActionResult Upsert(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (student.StudentId == 0)
                    {
                        _context.Students.Add(student);

                    }
                    else
                    {
                        var studentInDb = _context.Students.Find(student.StudentId);

                        if (studentInDb != null)
                        {
                            studentInDb.FirstName = student.FirstName;
                            studentInDb.LastName = student.LastName;
                            studentInDb.Gender = student.Gender;
                            studentInDb.DateOfBirth = student.DateOfBirth;
                            studentInDb.Email = student.Email;
                            studentInDb.PhoneNumber = student.PhoneNumber;
                            studentInDb.Address = student.Address;
                            studentInDb.Department = student.Department;
                            studentInDb.CourseId = student.CourseId;
                            studentInDb.Section = student.Section;
                            studentInDb.Semester = student.Semester;
                            studentInDb.AdmissionDate = student.AdmissionDate;
                            studentInDb.Status = student.Status;
                        }


                    }
                    _context.SaveChanges();

                    return RedirectToAction("Index");

                }

            }

            catch(Exception ex)
            {
                var i = ex.Message;
            }
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        
    }
}




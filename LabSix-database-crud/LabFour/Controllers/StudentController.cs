using LabFour.Data;
using LabFour.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LabFour.Controllers
{
    public class StudentController : Controller
    {
        ITIDB db;

        public StudentController(ITIDB _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {

            return View(db.Students.Include(a => a.Department).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.dept = new SelectList(db.Departments.ToList(), "DeptId", "DeptName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            db.Add(std);
            db.SaveChanges();
           return RedirectToAction("Index");

        }

        public IActionResult Details(int ? Id)
        {
            Student student = db.Students.Include(a => a.Department).ToList().FirstOrDefault(a => a.id == Id);

            //db.Students.Where(a => a.id == Id).FirstOrDefault();



            if (student == null)
            {
                return NotFound();
            }
            if (Id == null)
            {
                return BadRequest();
            }

            return View(student);

        }

        public IActionResult Delete(int ? id)
        {
            Student student = db.Students.Where(a => a.id == id).FirstOrDefault();

            if (student == null)
            {
                return NotFound();
            }
            if (id == null)
            {
                return BadRequest();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Edit(int ? Id)
        {
            Student student = db.Students.Where(a => a.id == Id).FirstOrDefault();
            ViewBag.dept = new SelectList(db.Departments.ToList(), "DeptId", "DeptName");



            if (Id == null)
            {
                return BadRequest();
            }

           if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        { 
            Student OldStd = db.Students.Where(a => a.id == student.id).FirstOrDefault();

            OldStd.name = student.name;
            OldStd.age = student.age;
            OldStd.email = student.email;
            OldStd.DeptNo = student.DeptNo;

            db.SaveChanges();

            return RedirectToAction("index");
        }
        
    }
}

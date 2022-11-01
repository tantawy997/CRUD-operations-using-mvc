using LabFour.Data;
using LabFour.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LabFour.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult myFun()
        {
            ITIDB db = new ITIDB();

            Department dept1 = new Department() { DeptName = ".net", DeptId=200 };
            db.Departments.Add(dept1);
            Student stud1 = new Student() { name="mohmaed", age=25, email="e.v@gmail.com", DeptNo=dept1.DeptId};
            db.Students.Add(stud1);
            db.SaveChanges();

            return Content("data has been added");
        }
    }
}
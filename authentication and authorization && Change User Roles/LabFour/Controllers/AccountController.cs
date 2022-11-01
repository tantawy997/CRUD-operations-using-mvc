using LabFour.Data;
using LabFour.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace LabFour.Controllers
{
    public class AccountController : Controller
    {
        ITIDB db = new ITIDB();

        public AccountController(ITIDB _db)
        {
            db = _db;
        }

        [Authorize(Roles = "instructor,Admin")]
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult accessdenied()
        {
            return View();
        }

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index","Home"); 

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if (ModelState.IsValid == false)
            {
                return View(Model);
            }
            var user =  db.Users.Include(a => a.Roles).FirstOrDefault(a => a.UserName == Model.username && a.password == Model.password);

            if (user != null)
            {

                
                Claim c1 = new Claim(ClaimTypes.Name, user.UserName);
                Claim c2 = new Claim("Age", user.Age.ToString());
                Claim c3 = new Claim(ClaimTypes.Name, user.UserName);

                Claim c4 = new Claim("password",user.password);

                //Claim c3 = new Claim(ClaimTypes.Role, "Admin");
                //Claim c4 = new Claim(ClaimTypes.Role, "Instructor");
                ClaimsIdentity ci = new ClaimsIdentity("Cookie");
                //ci.AddClaim(c1);
                //ci.AddClaim(c2);
                ci.AddClaim(c3);
                ci.AddClaim(c4);

                foreach (var item in user.Roles)
                {
                    ci.AddClaim(new Claim(ClaimTypes.Role, item.RoleName));
                }
                ClaimsPrincipal cp = new ClaimsPrincipal(ci);


                await HttpContext.SignInAsync(cp);

                return  RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("password", "password is not correct");
                ModelState.AddModelError("username", "username is not correct");
                return View(Model);
            }

            
        }
    }
}

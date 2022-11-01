using LabFour.Data;
using LabFour.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LabFour.Controllers
{
    public class ManageController : Controller
    {
        ITIDB db;
        
        public ManageController(ITIDB _db)
        {
            db = _db;
        }

        public IActionResult GetRoles()
        {
            ViewBag.Roles = new SelectList(db.Roles.ToList(), "Id", "RoleName");
            return View();
        }

        public IActionResult GetUsers(int RoleId)
        {
            // get user by his id in including his role 
            var Role = db.Roles.Include(a => a.Users).FirstOrDefault(role => role.Id == RoleId);
            var UserInRole = Role.Users.ToList();
            //get users not in role
            var AllUsers = db.Users.ToList();
            var UsersNotInRoles = AllUsers.Except(UserInRole);

            ViewBag.UserInRole = new SelectList(UserInRole, "Id", "Name");
            ViewBag.UsersNotInRoles = new SelectList(UsersNotInRoles, "Id", "Name");
            
            ViewBag.RoleId = RoleId;
            ViewBag.Roles = new SelectList(db.Roles.ToList(), "Id", "RoleName",RoleId);

            return View();
        }

        public IActionResult ChangeUserRoles(int RoleId, List<int>UserToAdd ,List<int>UserToRemove)
        {
            var role = db.Roles.Include(a => a.Users).FirstOrDefault(a => a.Id == RoleId);

            foreach(var item in UserToRemove)
            {
                role.Users.Remove(db.Users.FirstOrDefault(a => a.Id == item));
            }

            foreach(var item in UserToAdd)
            {
                role.Users.Add(db.Users.FirstOrDefault(a => a.Id == item));
            }
            db.SaveChanges();
            return RedirectToAction("GetRoles");
        }
    }
}

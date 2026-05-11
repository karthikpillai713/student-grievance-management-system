using Microsoft.AspNetCore.Mvc;
using WebApplicationFinal.Data;
using WebApplicationFinal.Models;
using System.Linq;

namespace WebApplicationFinal.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // REGISTER PAGE
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER POST
        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        // LOGIN PAGE
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetInt32("UserId", user.UserId);
                // Redirect based on role
                if (user.Role == "Student")
                    return RedirectToAction("Index", "Student");

                if (user.Role == "Teacher")
                    return RedirectToAction("Index", "Teacher");

                if (user.Role == "Principal")
                    return RedirectToAction("Index", "Principal");
            }

            ViewBag.Message = "Invalid Login";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
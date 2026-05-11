using Microsoft.AspNetCore.Mvc;
using WebApplicationFinal.Data;
using WebApplicationFinal.Models;
using System.Linq;

namespace WebApplicationFinal.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // View grievances
        public IActionResult Grievances()
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher")
            {
                return RedirectToAction("Login", "Account");
            }
            var grievances = _context.Grievances.ToList();

            return View(grievances);
        }

        // Mark solved
        public IActionResult Solve(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher")
            {
                return RedirectToAction("Login", "Account");
            }
            var grievance = _context.Grievances.Find(id);

            if (grievance != null)
            {
                grievance.Status = "Solved";

                _context.SaveChanges();
            }

            return RedirectToAction("Grievances");
        }

        // Forward to principal
        public IActionResult Forward(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher")
            {
                return RedirectToAction("Login", "Account");
            }
            var grievance = _context.Grievances.Find(id);

            if (grievance != null)
            {
                grievance.Status = "Forwarded";

                _context.SaveChanges();
            }

            return RedirectToAction("Grievances");
        }
    }
}
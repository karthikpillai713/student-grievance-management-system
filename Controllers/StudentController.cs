using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationFinal.Data;
using WebApplicationFinal.Models;
using System.Linq;

namespace WebApplicationFinal.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") != "Student")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // GET: Create grievance
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _context.Categories.ToList(),
                "CategoryId",
                "CategoryName"
            );

            return View();
        }

        // POST: Save grievance
        [HttpPost]
        public IActionResult Create(Grievance grievance)
        {
            if (HttpContext.Session.GetString("UserRole") != "Student")
            {
                return RedirectToAction("Login", "Account");
            }
            grievance.Status = "Pending";

            int? studentId = HttpContext.Session.GetInt32("UserId");

            grievance.StudentId = studentId ?? 0;

            _context.Grievances.Add(grievance);
            _context.SaveChanges();

            return RedirectToAction("MyGrievances");
        }

        // Show grievances
        public IActionResult MyGrievances()
        {
            if (HttpContext.Session.GetString("UserRole") != "Student")
            {
                return RedirectToAction("Login", "Account");
            }
            int? studentId = HttpContext.Session.GetInt32("UserId");

            var grievances = _context.Grievances
                .Where(g => g.StudentId == studentId)
                .ToList();

            return View(grievances);
        }
    }
}
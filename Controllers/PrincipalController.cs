using Microsoft.AspNetCore.Mvc;
using WebApplicationFinal.Data;
using System.Linq;

namespace WebApplicationFinal.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrincipalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") != "Principal")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // View all grievances
        public IActionResult Grievances()
        {
            if (HttpContext.Session.GetString("UserRole") != "Principal")
            {
                return RedirectToAction("Login", "Account");
            }
            var grievances = _context.Grievances.ToList();

            return View(grievances);
        }

        // Resolve grievance
        public IActionResult Resolve(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Principal")
            {
                return RedirectToAction("Login", "Account");
            }
            var grievance = _context.Grievances.Find(id);

            if (grievance != null)
            {
                grievance.Status = "Resolved";

                _context.SaveChanges();
            }

            return RedirectToAction("Grievances");
        }

        // Reject grievance
        public IActionResult Reject(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Principal")
            {
                return RedirectToAction("Login", "Account");
            }
            var grievance = _context.Grievances.Find(id);

            if (grievance != null)
            {
                grievance.Status = "Rejected";

                _context.SaveChanges();
            }

            return RedirectToAction("Grievances");
        }

        // Under Review
        public IActionResult Review(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Principal")
            {
                return RedirectToAction("Login", "Account");
            }
            var grievance = _context.Grievances.Find(id);

            if (grievance != null)
            {
                grievance.Status = "Under Review";

                _context.SaveChanges();
            }

            return RedirectToAction("Grievances");
        }
    }
}
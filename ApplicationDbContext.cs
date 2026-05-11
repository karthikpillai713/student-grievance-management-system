using Microsoft.EntityFrameworkCore;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Grievance> Grievances { get; set; }
    }
}
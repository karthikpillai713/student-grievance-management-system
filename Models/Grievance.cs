using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationFinal.Models
{
    public class Grievance
    {
        public int GrievanceId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int StudentId { get; set; }

        public int? AssignedTeacherId { get; set; }

        public string Status { get; set; }

        public string? PrincipalRemark { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }
    }
}
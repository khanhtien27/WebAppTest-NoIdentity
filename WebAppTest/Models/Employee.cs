using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTest.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Sex { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
        public string? Address { get; set; }

        [Required]
        [ForeignKey("department")]
        public int IdDepartment { get; set; }
        public Department? department { get; set; }

        public string? Img { get; set; }

        [Required]
        public string Password { get; set; }
        
        public DateTime? Create_At { get; set; } = DateTime.Now;

    }
}

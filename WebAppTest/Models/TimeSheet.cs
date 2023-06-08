using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace WebAppTest.Models
{
    public class TimeSheet
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdEmployment")]
        public int IdEmployment { get; set; }
        public Employee employee { get; set; }

        [Required]
        public DateTime Start { get; set; }
        public DateTime? BreakStart { get; set; }
        public DateTime? BreakEnd { get; set; }
        
        [Required] 
        public DateTime End { get; set; }
    }
}

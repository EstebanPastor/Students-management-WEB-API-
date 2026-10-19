using System.ComponentModel.DataAnnotations;

namespace WebAPISolution.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string Surname { get; set; }
    }
}
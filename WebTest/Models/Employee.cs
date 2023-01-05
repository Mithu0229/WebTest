using System.ComponentModel.DataAnnotations;

namespace WebTest.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }

    }
}

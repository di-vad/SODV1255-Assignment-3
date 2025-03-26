using System.ComponentModel.DataAnnotations;

namespace libraryManagementSystem.Models
{
    public class Reader
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}

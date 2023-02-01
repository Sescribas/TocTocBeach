using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TocTocBeach.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKeyAttribute("UserTypeId")]
        public int UserTypeId { get; set; }

    }
}

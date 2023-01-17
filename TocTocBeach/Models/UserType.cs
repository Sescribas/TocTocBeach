using System.ComponentModel.DataAnnotations;

namespace TocTocBeach.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

    }
}

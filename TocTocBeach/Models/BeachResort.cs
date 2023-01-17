using System.ComponentModel.DataAnnotations;

namespace TocTocBeach.Models
{
    public class BeachResort
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int BeachResortInfoId { get; set; }
    }
}

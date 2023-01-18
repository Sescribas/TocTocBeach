using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TocTocBeach.Models
{
    public class BeachResort
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int BeachResortInfoId { get; set; }

        [ForeignKey("BeachResortInfoId")]
        public BeachResortInfo BeachResortInfo { get; set;}
    }
}

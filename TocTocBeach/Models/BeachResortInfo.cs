using System.ComponentModel.DataAnnotations;

namespace TocTocBeach.Models
{
    public class BeachResortInfo
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }


    }
}

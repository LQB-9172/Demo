using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Video")]
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        public required string VideoUrl { get; set; }
        public string? Description { get; set; }
    }

}

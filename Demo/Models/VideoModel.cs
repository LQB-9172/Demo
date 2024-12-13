using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class VideoModel
    {
        public int VideoId { get; set; }
        public string? VideoUrl { get; set; }
        public string? Description { get; set; }

    }
}

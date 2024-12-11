namespace Demo.Models
{
    public class VideoModel
    {
        public int VideoId { get; set; }
        public required string VideoUrl { get; set; }
        public string? Description { get; set; }
    }
}

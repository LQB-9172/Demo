namespace Demo.Models
{
    public class AudioModel
    {
        public int AudioId { get; set; }
        public required string AudioUrl { get; set; }
        public string? Description { get; set; }
    }
}

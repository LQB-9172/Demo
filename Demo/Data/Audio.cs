using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Audio")]
    public class Audio
    {
        [Key]
        public int AudioId { get; set; }
        public required string AudioUrl { get; set; }
        public string? Description { get; set; }
    }

}

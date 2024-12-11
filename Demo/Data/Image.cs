using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Image")]
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public required string ImageUrl { get; set; }
        public required string AudioUrl { get; set; }
        public string? Description { get; set; }
    }

}

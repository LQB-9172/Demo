using System.ComponentModel.DataAnnotations.Schema;

namespace test.Data
{
    [Table("Image")]
    public class Image
    {
        public int ImageID { get; set; }
        public virtual Lesson? Lesson { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Question? Question { get; set; }
        public virtual Exercise? Exercise { get; set; }
        public required string ImageUrl { get; set; }
        public string? Description { get; set; }

    }

}

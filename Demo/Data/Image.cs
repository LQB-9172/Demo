using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Image")]
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string? AudioUrl { get; set; }

        public string? Description { get; set; }

        public int LessonID { get; set; } // Foreign Key
        [ForeignKey("LessonID")]
        public virtual Lesson Lesson { get; set; } // Navigation property
    }


}

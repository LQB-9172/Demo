using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Data
{
    [Table("Lesson")]
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }


        public virtual ICollection<Image>? Image { get; set; }
        public virtual ICollection<Audio>? Audio { get; set; }
        public virtual ICollection<Exercise>? Exercise { get; set; }
    }
}

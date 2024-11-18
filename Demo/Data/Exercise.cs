using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int LessonID { get; set; }
        public virtual Lesson? Lesson { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Exercise()
        {
            Questions = new HashSet<Question>();
        }
    }
}

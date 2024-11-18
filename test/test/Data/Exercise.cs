using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Data
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }
        public int LessonID { get; set; }
        public string? Question { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? AnswerType { get; set; }
        public int? AudioID { get; set; }

        public virtual Lesson? Lesson { get; set; }
        public virtual ICollection<Image>? Image { get; set; }
        public virtual ICollection<Audio>? Audio { get; set; }


    }
}

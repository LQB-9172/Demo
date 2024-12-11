using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo.Data
{
    [Table("StudentLesson")]
    public class StudentLesson
    {
        [Key]
        public int StudentLessonID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Lesson")]
        public int LessonID { get; set; }
        public virtual Lesson Lesson { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}


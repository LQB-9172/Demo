using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace test.Data
{
    [Table("Progress")]
    public class Progress
    {
        [Key]
        public int ProgressID { get; set; }
        public int StudentID { get; set; }
        public int LessonID { get; set; }
        public int? TestID { get; set; }
        public DateTime? CompleteDate { get; set; }
        public int TimeSpent { get; set; }
        public bool Completed { get; set; }

        public virtual Student? Student { get; set; }
        public virtual ICollection<Lesson>? Lesson { get; set; }
        public virtual ICollection<Test>? Test { get; set; }
    }
}

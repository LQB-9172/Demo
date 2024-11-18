using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Progress")]
    public class Progress
    {
        [Key]
        public int ProgressID { get; set; }
        public int StudentID { get; set; }

        public virtual Student? Student { get; set; }

        public double CompletionPercentage { get; set; }
        public  virtual ICollection<Test> Tests { get; set; }
        public  virtual ICollection<Lesson> Lessons { get; set; }

        public Progress()
        {
            CompletionPercentage = 0;
            Tests = new HashSet<Test>();
            Lessons = new HashSet<Lesson>();
        }
    }

}

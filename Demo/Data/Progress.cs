using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Progress")]
    public class Progress
    {
        [Key]
        public int ProgressID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public double CompletionPercentage { get; set; }

    }

}

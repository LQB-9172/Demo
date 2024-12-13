using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("TestResult")]
    public class TestResult
    {
        [Key]
        public int TestResultId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int TotalQuestions { get; set; }

        [Required]
        public int CorrectAnswers { get; set; }

        [Required]
        public double Score { get; set; }

        [Required]
        public DateTime CompletionDate { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}

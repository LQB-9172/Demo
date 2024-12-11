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
        public int StudentId { get; set; } // ID học sinh thực hiện bài kiểm tra

        [Required]
        public int TotalQuestions { get; set; } // Tổng số câu hỏi

        [Required]
        public int CorrectAnswers { get; set; } // Số câu trả lời đúng

        [Required]
        public double Score { get; set; } // Điểm số (phần trăm)

        [Required]
        public DateTime CompletionDate { get; set; } // Ngày hoàn thành

        // Quan hệ với bảng Student
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}

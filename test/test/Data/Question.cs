using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Data
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public virtual ICollection<Image>? Image { get; set; }
        public int TestID { get; set; }
        public required string QuestionText { get; set; }
        public required string Answer1 { get; set; }
        public required string Answer2 { get; set; }
        public required string Answer3 { get; set; }
        public required string Answer4 { get; set; }
        public required int CorrectAnswer { get; set; }

        public virtual Test? Test { get; set; }


    }
}

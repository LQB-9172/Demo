namespace Demo.Models
{
    public class ListeningModel
    {
        public int QuestionID { get; set; }
        public required string QuestionText { get; set; }
        public required string Answer1 { get; set; }
        public required string Answer2 { get; set; }
        public required string Answer3 { get; set; }
        public required string Answer4 { get; set; }
        public required int? CorrectAnswer { get; set; }

    }
}

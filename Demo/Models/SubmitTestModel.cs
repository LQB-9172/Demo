namespace Demo.Models
{
    public class SubmitTestModel
    {
        public int StudentId { get; set; }
        public List<QuestionAnswerModel> Answers { get; set; }
    }

    public class QuestionAnswerModel
    {
        public int QuestionId { get; set; }
        public int SelectedAnswer { get; set; }
    }

}

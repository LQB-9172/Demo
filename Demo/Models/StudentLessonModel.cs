namespace Demo.Models
{
    public class StudentLessonModel
    {
        public int LessonID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}

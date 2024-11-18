using System.ComponentModel.DataAnnotations.Schema;

namespace test.Data
{
    [Table("Audio")]
    public class Audio
    {
        public int AudioID { get; set; }
        public required string AudioURL { get; set; }
        public string? Description { get; set; }


        //FK Lesson
        public int? LessonID { get; set; }
        public virtual Lesson? Lesson { get; set; }
    }
}

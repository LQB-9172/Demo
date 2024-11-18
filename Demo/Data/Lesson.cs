using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Lesson")]
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int completed { get; set; }

        public virtual ICollection<Audio> Audios { get; set; }
        public virtual ICollection<Image> Images { get; set; } 

        public Lesson() 
        {
            completed=0;
            Audios = new List<Audio>();
            Images = new List<Image>();
        }

    }
}

using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Lesson")]
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LessonID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int Completed { get; set; }

        public virtual ICollection<Audio> Audios { get; set; }
        public virtual ICollection<Image> Images { get; set; } 

        public Lesson() 
        {
            Completed=0;
            Audios = new List<Audio>();
            Images = new List<Image>();
        }

    }
}

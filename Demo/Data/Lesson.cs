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
        public string? TitleUrl { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        public Lesson()
        {
            Videos = new List<Video>();
            Images = new List<Image>();
        }

    }
}

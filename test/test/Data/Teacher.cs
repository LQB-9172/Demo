using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace test.Data
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public virtual ICollection<Image>? Image { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public virtual User? User { get; set; }

    }
}

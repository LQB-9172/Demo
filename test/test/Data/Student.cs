using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Data
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public virtual ICollection<Image>? Image { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }


        public virtual User? User { get; set; }
        public virtual Progress? Progress { get; set; }



    }
}

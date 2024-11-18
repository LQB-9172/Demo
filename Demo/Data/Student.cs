using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Demo.Data
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string PassWord { get; set; }
        public  string? ImageUrl { get; set; }
    }
}

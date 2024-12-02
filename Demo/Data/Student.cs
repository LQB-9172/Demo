using Microsoft.AspNetCore.Identity;
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
        public DateTime DateOfBirth { get; set; }
        public  string? ImageUrl { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}

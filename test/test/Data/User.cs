using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Data
{
    [Table("User")]   
    public class User
    {   
        [Key]
        public int UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required bool Role { get; set; }


        public virtual ICollection<Student>? Student { get; set; }
        public virtual ICollection<Teacher>? Teacher { get; set; }
    }
}

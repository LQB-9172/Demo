using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int TestID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Score { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Test()
        {
            Questions = new HashSet<Question>();
        }
    }
}

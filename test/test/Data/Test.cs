using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Data
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int TestID { get; set; }
        public required string Title { get; set; }
        public int MaxScore { get; set; }


       public virtual required ICollection<Question> Questions { get; set; }
    }
}

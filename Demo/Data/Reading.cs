using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo.Data
{
    [Table("Reading")]
    public class Reading
    {
        [Key]
        public int QuestionID { get; set; }
        public required string Url { get; set; }
        public required string text { get; set; }

    }
}

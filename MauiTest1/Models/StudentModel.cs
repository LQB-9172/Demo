using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTest1.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string PassWord { get; set; }
        public string? ImageUrl { get; set; }
    }
}

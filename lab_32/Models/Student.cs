using System.Text.RegularExpressions;

namespace EfInheritanceLab.Models
{
    public class Student : Person
    {
        public string? StudentNumber { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}

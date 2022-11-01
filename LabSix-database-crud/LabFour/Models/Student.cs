using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabFour.Models
{
    public class Student
    {

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        public int age { get; set; }

        public string email { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }

        public Department Department { get; set; }

        public Student()
        {
            StudentCourses = new List<StudentCourses>();
        }

    }
}

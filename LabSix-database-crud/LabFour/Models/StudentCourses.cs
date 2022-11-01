using System.ComponentModel.DataAnnotations.Schema;

namespace LabFour.Models
{
    public class StudentCourses
    {
        [ForeignKey("Student")]

        public int stdId { get; set; }

        [ForeignKey("Course")]
        public int CrsId { get; set; }

        public int Degree { get; set; }
        
        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}

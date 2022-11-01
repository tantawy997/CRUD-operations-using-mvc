using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabFour.Models

{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string DeptName { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Course> Courses { get; set; }

        public Department()
        {
            Students = new HashSet<Student>();
            Courses = new HashSet<Course>();

        }

        //public Department()
        //{
        //    Courses = new HashSet<Course>();
        //}

    }
}

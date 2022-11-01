namespace LabFour.Models
{
    public class Course
    {

        public int CrsId { get; set; }

        public string CrsName { get; set; }

        public int Crs_Hours { get; set; }

        public ICollection<Department> Departments { get; set; } 

        public ICollection<StudentCourses> StudentCourses { get; set; }  

        public Course()
        {
            Departments = new HashSet<Department>();
            StudentCourses = new HashSet<StudentCourses>();


        }
    }
}

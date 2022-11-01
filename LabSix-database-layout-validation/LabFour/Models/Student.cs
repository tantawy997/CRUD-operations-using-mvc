using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabFour.Models
{
    public class Student
    {

        public int id { get; set; }

        [Required(ErrorMessage = "name must be included")]
        [StringLength(20, MinimumLength = 3)]
        public string name { get; set; }

        [Range(10, 30, ErrorMessage = "age must be between 10 and 30")]
        public int age { get; set; }

        [Required]
        [Remote("CheckUserName","Student",AdditionalFields = "id", HttpMethod = "POST")]
        public string username { get; set; }

        
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}",ErrorMessage ="email does not meet email specifications")]
        public string email { get; set; }

        //[Required]
        [DataType(DataType.Password)]
        public string  password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string  Cpassword { get; set; }

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

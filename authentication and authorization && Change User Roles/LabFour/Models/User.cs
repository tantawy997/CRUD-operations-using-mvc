using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabFour.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [Range(10, 30)]
        public int Age { get; set; }

        [Required]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string Cpassword { get; set; }

        public ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
        }

    }
}

using System.ComponentModel.DataAnnotations;

namespace LabFour.Models
{
    public class LoginViewModel
    {
        [Required]
        public string username { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
    }
}

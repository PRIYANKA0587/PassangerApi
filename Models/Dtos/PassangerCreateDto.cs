using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassangerApi.Models.Dtos
{
    public class PassangerCreateDto
    {
       
        [Required(ErrorMessage = "Enter your Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter your age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Adhar Number")]
        public string Adhar { get; set; }
    }
}

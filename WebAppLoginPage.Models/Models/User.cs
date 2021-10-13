using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppLoginPage.Models.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(20, ErrorMessage = "Name not be Exceed 20!")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^.*(?=.{12,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=().,<>]).*$", ErrorMessage = "Please Input valid Password")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Input valid Email")]
        public string Email { get; set; }
    }
}

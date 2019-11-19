using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18_CoffeeShop.Models
{
    public class RegisterUser
    {
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Not a Valid Name!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Not a Valid Name!")]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]{3,30}@[A-Za-z]{3,10}\.[A-Za-z]{2,3}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage= "Invalid Username")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Invalid Password!")]
        public string PassWord { get; set; }

        public RegisterUser() { }

        public RegisterUser(string firstName, string lastName, DateTime dob, string email, string userName, string passWord)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Email = email;
            UserName = userName;
            PassWord = passWord;
        }

    }
}

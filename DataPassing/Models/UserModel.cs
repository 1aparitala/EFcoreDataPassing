
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataPassing.Attributes;

namespace DataPassing.Models
{
    public class UserModel
    {
        [Required(ErrorMessage ="Please enter User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter Password")]
        public string  password { get; set; }

        [Required(ErrorMessage ="Please enter Confirm Password")]
        [Compare("password", ErrorMessage ="Confirm Password doesn't match")]
        public string Confirmpassword { get; set; }
       
        [ValidateCheckBox(ErrorMessage ="Please accept terms")]
        public bool Terms{ get; set; }

    }
}

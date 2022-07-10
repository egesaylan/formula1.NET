using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Formula1.Entities.ValueObjects
{
    public class RegisterViewMDL
    {

        [DisplayName("Username"), 
            Required(ErrorMessage = "{0} can't be skipped"), 
            StringLength(25,ErrorMessage = "{0} max. {1} characters")]
        public string Username { get; set; }

        [DisplayName("E-Mail"), 
            Required(ErrorMessage = "{0} can't be skipped"), 
            StringLength(70, ErrorMessage = "{0} max. {1} characters"), 
            EmailAddress(ErrorMessage ="For the field {0} enter a valid e-mail")]
        public string Email { get; set; }


        [DisplayName("Password"), 
            Required(ErrorMessage = "{0} can't be skipped"), 
            StringLength(20, ErrorMessage = "{0} max. {1}  characters")]
        public string Password { get; set; }


        [DisplayName("Password"), Required(ErrorMessage = "{0} can't be skipped"), 
            StringLength(20, ErrorMessage = "{0} max. {1}  characters"), 
            Compare("Password", ErrorMessage ="{0} and {1} does not match")]
        public string RePassword { get; set; }

    }
}
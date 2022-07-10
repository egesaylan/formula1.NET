using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Formula1.Entities.ValueObjects
{
    public class LoginViewMdl
    {
        [DisplayName("Username"), Required(ErrorMessage = "{0} can't be skipped"), StringLength(25, 
            ErrorMessage = "{0} max. {1} characters")]
        public string Username { get; set; }
        [DisplayName("Password"), Required(ErrorMessage = "{0} can't be skipped"), DataType(DataType.Password), StringLength(20,
            ErrorMessage = "{0} max. {1} 20 characters")]
        public string Password { get; set; }
    }
}

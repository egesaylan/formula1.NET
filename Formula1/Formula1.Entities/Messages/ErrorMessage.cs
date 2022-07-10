using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Entities.Messages
{
    public enum ErrorMessage
    {
        UsernameAlreadyExist = 101,
        EmailAlreadyExist = 102,
        UserIsNotActive = 151,
        UsernameOrPasswordWrong = 152,
        CheckYourEmail = 153,
        UserNotFound = 154,
        ProfileCouldNotUpdated = 155,
        UserCouldNotRemove = 156,
        UserCouldNotFind = 157
    }
}

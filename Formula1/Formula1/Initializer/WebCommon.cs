using Formula1.Common;
using Formula1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Formula1.Initializer
{
    public class WebCommon : ICommon
    {
        public string GetUsername()
        {
            if(HttpContext.Current.Session["login"] != null)
            {
                Formula1User user = HttpContext.Current.Session["login"] as Formula1User;
                return user.Username;
            }
            return null;
        }
    }
}
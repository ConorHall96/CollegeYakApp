using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeYakApp
{   
    class LoggedInUser
    {
        private String loggedinUN;
        private String loggedinPW;

        public LoggedInUser(String username)
        {
            this.loggedinUN = username;
        }

        public String getLoggedInUN()
        {
            return loggedinUN;
        }
    }
}

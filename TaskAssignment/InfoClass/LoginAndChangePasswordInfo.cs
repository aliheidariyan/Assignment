using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAssignment.InfoClass
{
    public class LoginAndChangePasswordInfo
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string RepeateNewPassword { get; set; }
        public bool PasswordHasChangedWithLogin { get; set; }
    }
}

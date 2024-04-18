using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Name
        {
            get { return _user.names; }
            set { _user.names = value; }
        }

        public string FacultyNumber
        
        {
            get { return _user.facultyNumber; }
            set { _user.facultyNumber = value; }
        }

        public UserRolesEnum UserRolesEnum
        {
            get { return _user.roles; }
            set { _user.roles = value; }
        }


   

    }
}

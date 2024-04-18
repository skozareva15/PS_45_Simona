using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string _names;
        public string _password;
        public UserRolesEnum _roles;
        private string _facultyNumber;
  
        private UserRolesEnum aDMIN;
        public  int _id;
        public DateTime _expires;

    
        public User() { }


        public User(string names, string password, string facultyNumber, UserRolesEnum role)
        {
            _names = names;
            _password = password;
            _facultyNumber = facultyNumber;
            _roles = role;

        }


        public User(string username, string password, UserRolesEnum role)
        {
            this.password = password;
            this.roles = role;
        }

        public string names
        {
            get { return _names; }
            set { _names = value; }
        }


        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public UserRolesEnum roles
        {
            get { return _roles; }
            set { _roles = value; }
        }
       public string facultyNumber
        {
            get { return facultyNumber; }
            set { _facultyNumber = value; }
        }
     
        public virtual int Id
        {
            get { return Id; }
            set { _id = value; }

        }
        public DateTime expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
        private string Encrypt(string clearText)
        {
            byte[] encryptedBytes = Encoding.Unicode.GetBytes(clearText);//АES
            return Convert.ToBase64String(encryptedBytes);
        }

        private string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            return Encoding.Unicode.GetString(cipherBytes);
        }
    }
}




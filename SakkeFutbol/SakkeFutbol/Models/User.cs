using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SakkeFutbol.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(this.UserName) || string.IsNullOrEmpty(this.Password))
                return false; 
            else 
                return true;
        }
    }
}

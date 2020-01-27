using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPatterns
{
    class User
    {
        private string username;
        private string password;
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string GetUsername()
        {
            return username;
        }
        public string GetPassword()
        {
            return password;
        }
    }
}

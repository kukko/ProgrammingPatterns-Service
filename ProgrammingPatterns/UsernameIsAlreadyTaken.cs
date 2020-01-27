using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPatterns
{
    class UsernameIsAlreadyTaken : Exception
    {
        private string username;
        public UsernameIsAlreadyTaken(string username) : base("A felhasználónév már foglalt: " + username)
        {
            this.username = username;
        }
        public string GetUsername()
        {
            return username;
        }
    }
}

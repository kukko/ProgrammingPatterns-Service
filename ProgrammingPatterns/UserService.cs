using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPatterns
{
    class UserService
    {
        private static string GetFilename()
        {
            return "users.csv";
        }
        public static User CreateUser(string username, string password)
        {
            if (UsernameAlreadyExists(username))
            {
                throw new UsernameIsAlreadyTaken(username);
            }
            return WriteUserToFile(username, password);
        }

        private static User WriteUserToFile(string username, string password)
        {
            File.AppendAllLines(GetFilename(), new string[] {
                PrepareUserForFile(username, password)
            });
            return new User(username, password);
        }

        private static string PrepareUserForFile(string username, string password)
        {
            return username + ";" + password;
        }

        public static bool UsernameAlreadyExists(string username)
        {
            if (File.Exists(GetFilename()))
            {
                StreamReader usersStream = new StreamReader(GetFilename());
                string line;
                while ((line = usersStream.ReadLine()) != null)
                {
                    User currentUser = ParseUser(line);
                    if (currentUser.GetUsername() == username)
                    {
                        usersStream.Close();
                        return true;
                    }
                }
                usersStream.Close();
            }
            return false;
        }
        private static User ParseUser(string line)
        {
            string[] data = line.Split(';');
            return new User(data[0], data[1]);
        }

        public static User GetUserByUsername(string username)
        {
            if (File.Exists(GetFilename()))
            {
                StreamReader usersStream = new StreamReader(GetFilename());
                string line;
                while ((line = usersStream.ReadLine()) != null)
                {
                    User currentUser = ParseUser(line);
                    if (currentUser.GetUsername() == username)
                    {
                        usersStream.Close();
                        return currentUser;
                    }
                }
                usersStream.Close();
            }
            return null;
        }
    }
}

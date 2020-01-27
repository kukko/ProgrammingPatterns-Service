using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPatterns
{
    class AuthenticateService
    {
        private static User authenticatedUser;
        public static User AuthenticateUser(string username, string password)
        {
            User output = UserService.GetUserByUsername(username);
            if (output != null)
            {
                if (output.GetPassword() == password)
                {
                    Logger.Log("LOGIN", username + ":" + password + "=true");
                    return authenticatedUser = output;
                }
            }
            Logger.Log("LOGIN", username + ":" + password + "=false");
            return null;
        }
        public static void LogoutUser()
        {
            Logger.Log("LOGOUT", authenticatedUser.GetUsername());
            authenticatedUser = null;
        }
        public static User GetAuthenticatedUser()
        {
            return authenticatedUser;
        }
    }
}

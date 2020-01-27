using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldRerun = true;
            string choice;
            do
            {
                User authenticatedUser = AuthenticateService.GetAuthenticatedUser();
                if (authenticatedUser == null)
                {
                    Console.WriteLine("Mit szeretnél csinálni?");
                    Console.WriteLine("1. Bejelentkezés");
                    Console.WriteLine("2. Regisztráció");
                    Console.WriteLine("3. Kilépés");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Login();
                            break;
                        case "2":
                            Register();
                            break;
                        case "3":
                            shouldRerun = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Üdv, " + authenticatedUser.GetUsername() + "!");
                    Console.WriteLine("Mit szeretnél csinálni?");
                    Console.WriteLine("1. Kijelentkezés");
                    Console.WriteLine("2. Kilépés");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Logout();
                            break;
                        case "2":
                            shouldRerun = false;
                            break;
                    }
                }
            } while (shouldRerun);
        }
        static void Login()
        {
            Console.WriteLine("Bejelentkezés");
            bool userLoggedIn = false;
            while (!userLoggedIn)
            {
                Console.Write("Felhasználónév: ");
                string username = Console.ReadLine();
                Console.Write("Jelszó: ");
                string password = Console.ReadLine();
                User authenticatedUser = AuthenticateService.AuthenticateUser(username, password);
                if (authenticatedUser != null)
                {
                    userLoggedIn = true;
                }
                else
                {
                    Console.WriteLine("Helytelen felhasználónév és jelszó páros!");
                }
            }
        }
        static void Logout()
        {
            AuthenticateService.LogoutUser();
        }
        static void Register()
        {
            Console.WriteLine("Regisztráció");
            bool userCreated = false;
            while (!userCreated)
            {
                Console.Write("Felhasználónév: ");
                string username = Console.ReadLine();
                Console.Write("Jelszó: ");
                string password = Console.ReadLine();
                try
                {
                    UserService.CreateUser(username, password);
                    userCreated = true;
                }
                catch (UsernameIsAlreadyTaken e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

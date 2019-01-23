using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_7
{
    class Program
    {
        public static List<string> validEmail = new List<string>();
        public static List<string> validPass = new List<string>();

        static void Main()
        {
            Console.WriteLine("Email must consist of: 3 character name and domain.");
            bool run = true;
            while (run == true)
            {
                
                Console.Write("Enter Email: ");
                string userName = Console.ReadLine();

                bool user = UserName(userName);
                if (user == true)
                {
                    Console.WriteLine("\n" + userName + " is valid.\n");
                    validEmail.Add(userName);
                    run = false;
                }
                else
                {
                    Console.WriteLine("\n" + userName + " is an invalid email.\n");
                }
            }
            Console.WriteLine("Password must be 5 characters long and consist of 1 uppercase, 1 lowercase, 1 number");
            bool run2 = true;
            while (run2 == true)
            {
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                bool pass = Password(password);
                if (pass == true)
                {
                    Console.WriteLine("\n" + password + " is valid.\n");
                    validPass.Add(password);
                    run2 = false;
                }
                else
                {
                    Console.WriteLine("\n" + password + " is an invalid password.\n");
                }
            }
            Continue();
        }
        public static bool UserName(string userName)
        {
            string name = "^[a-zA-Z0-9]{3,11}[@][a-zA-Z0-9]{3,11}[.][a-zA-Z]{2,3}$";
            Regex test = new Regex(name);
            return test.IsMatch(userName);
        }
        public static bool Password(string password)
        {
            string pass = "^(?=.*[a-zA-Z0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{5,36}$";
            Regex test = new Regex(pass);
            return test.IsMatch(password);
        }
        public static bool Continue()
        {
            Console.Write("Input more data? (y/n): ");
            string input = Console.ReadLine().ToLower();

            bool cont = true;
            if (input == "y")
            {
                Console.Clear();
                Main();
                cont = true;
            }
            else if (input == "n")
            {
                Console.Clear();
                Console.WriteLine("Your list contains");
                string email = "        Email";
                string pass = "        Password";
                string seperate = "========================";

                Console.WriteLine("\n{0,-36}{1,-36}\n{2,-36}{2,-36}\n", email, pass, seperate);

                for (int i = 0; i < validEmail.Count; i++)
                {
                    //\n\n{3,-36}{3,-36}\n
                    Console.WriteLine("{2}: {0,-33}{2}: {1,-36}\n", validEmail[i], validPass[i], i + 1);
                    cont = false;
                }
                Console.WriteLine("{0,-36}{0,-36}\n", seperate);
                Console.WriteLine("Good Bye!\n\nPress any key to exit...");
                Console.ReadKey();
            }
            else
            {
                Console.Beep(); Console.Beep(); Console.Beep();
                Console.WriteLine("Invalid Response");
                cont = Continue();
            }
            return cont;
        }
    }
}
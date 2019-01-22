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
            
            bool run = true;
            while (run == true)
            {                
                Console.Write("Enter Username: ");
                string userName = Console.ReadLine();
                bool user = UserName(userName);

                 if (user == true)
                    {
                        Console.WriteLine(userName + " is valid.");
                        validEmail.Add(userName);
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine(userName + " is an invalid email.");
                    }
                }

            bool run2 = true;
            while (run2 == true)
            {
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                bool pass = Password(password);
                if (pass == true)
                {
                    Console.WriteLine(password + " is valid.");
                    validPass.Add(password);
                    run2 = false;
                }
                else
                {
                    Console.WriteLine(password + " is an invalid password.");
                }
            }
            Continue();
        }
        public static bool UserName(string userName)
        {
            string name = "^[a-zA-Z0-9]{3,11}[@][a-zA-Z]{3,11}[.][a-zA-Z]{2,3}$";
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
                Console.WriteLine("Email Address\t\tPassword\n=============\t\t==========\n");
                for ( int i = 0; i < validEmail.Count; i++)
                {  
                    Console.WriteLine(validEmail[i] + "\t\t" + validPass[i]);
                    cont = false;
                }
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

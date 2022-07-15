using Fitness.BL.Controller;
using System;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Oleksandr's program");
            Console.WriteLine("Enter your username");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("weight"); 
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter your birthdate: ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                }
            }

            return birthDate;
        }

        public static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter your {name}: ");
                if (Double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid {name} format");
                }
            }
        }
    }
}

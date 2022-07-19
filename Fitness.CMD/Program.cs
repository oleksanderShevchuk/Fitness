using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resorceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resorceManager.GetString("Hello", culture));
            Console.WriteLine(resorceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write(resorceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("weight"); 
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What you want to do?");
            Console.WriteLine("E - conduct a meal reception");

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                
            }
            foreach (var item in eatingController.Eating.Foods)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
             
            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Write name of product:");
            var food = Console.ReadLine();

            var calorie = ParseDouble("calorie");
            var prots = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbohydrates");


            var weight = ParseDouble("weight");
            var product = new Food(food, calorie, prots, fats, carbs);

            return (Food: product,Weight: weight);
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

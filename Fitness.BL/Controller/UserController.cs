using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя. 
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Пользователь придложение
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Создание нового контроллера пользователя. 
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Username cannot be empty", nameof(userName));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// Получить сохранений список пользователь.
        /// </summary>
        /// <returns> Пользователь приложение. </returns>
        /// <exception cref="FileLoadException"></exception>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
        public void SetNewUserData(string genderName, DateTime birthdate, double weight = 1, double height = 1)
        {
            // Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthdate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Сохранить дание пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
        
        
    }
}

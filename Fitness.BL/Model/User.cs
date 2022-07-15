using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата роджения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес пользователя
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост пользователя
        /// </summary>
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> День рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, Gender gender,
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region condition check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username cannot be empty or null", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Gender cannot be null", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("BirthDate is impossible", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Weight cannot be less than or equal to zero", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height cannot be less than or equal to zero", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username cannot be empty or null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}

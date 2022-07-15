using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новий пол.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> Имя пола. </exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The gender name cannot be empty or null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}

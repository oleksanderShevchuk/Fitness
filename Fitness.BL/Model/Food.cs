using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жири
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводи
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории за 100г продукта
        /// </summary>
        public double Calorie { get; }
        private double CaloriesOneGramm { get { return Calorie / 100.0; } }
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        private double FatsOneGramm { get { return Fats / 100.0; } }
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }
        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO: проверка
            Name =name;
            Calorie = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

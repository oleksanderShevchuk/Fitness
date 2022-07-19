using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NANE = "foods.dat";
        private const string EATING_FILE_NANE = "eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User cannot be empty.", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NANE) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NANE) ?? new List<Food>();
        }
        private void Save()
        {
            Save(FOODS_FILE_NANE, Foods);
        }
    }
}

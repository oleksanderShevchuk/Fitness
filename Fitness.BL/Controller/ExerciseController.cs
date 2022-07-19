using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISE_FILE_NANE = "exercises.dat";
        private const string ACTIVITY_FILE_NANE = "activities.dat";
        private User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }
        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITY_FILE_NANE) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }
        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISE_FILE_NANE) ?? new List<Exercise>();
        }
        private void Save()
        {
            Save(EXERCISE_FILE_NANE, Exercises);
            Save(ACTIVITY_FILE_NANE, Activities);
        }
    }
}

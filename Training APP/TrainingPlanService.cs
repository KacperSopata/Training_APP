using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Training_APP
{
    public class TrainingPlanService
    {
        private List<TrainingPlan> trainingPlansList = new List<TrainingPlan>();

        public void AddTrainnigPlan()
        {
            bool addTrainingPlan = true;
            while (addTrainingPlan)
            {
                Console.WriteLine("Insert the category of the Training Plan: Push, Pull, Legs.");
                string category = Console.ReadLine();
                Console.WriteLine("Insert the day for the Training Plan.");
                string day = Console.ReadLine();
                Console.WriteLine("How many exercises do you want to add to the Training Plan?");
                int exerciseCount;
                while (!int.TryParse(Console.ReadLine(), out exerciseCount) || exerciseCount <= 0)
                {
                    Console.WriteLine("Invalid input. Please insert a plus number..");
                }
                List<string> exercises = new List<string>();
                for (int i = 1; i <= exerciseCount; i++)
                {
                    Console.WriteLine($"Insert the name of exercise {i}:");
                    string exerciseName = Console.ReadLine();
                    exercises.Add(exerciseName);
                }
                Console.WriteLine("Insert how many sets: ");
                int sets;
                while (!int.TryParse(Console.ReadLine(), out sets) || sets <= 0)
                {
                    Console.WriteLine("Invalid inputPlease insert a plus number..");
                }
                Console.WriteLine("Insert how many repetitions: ");
                int repetitions;
                while (!int.TryParse(Console.ReadLine(), out repetitions) || repetitions <= 0)
                {
                    Console.WriteLine("Invalid input.Please insert a plus number..");
                }
                int id = trainingPlansList.Count + 1;
                string namesExercises = string.Join(", ", exercises);
                TrainingPlan addedTrainingPlan = new TrainingPlan(id, category, day, namesExercises, sets, repetitions);
                trainingPlansList.Add(addedTrainingPlan);
                Console.WriteLine($"Training Plan added successfully. It's id = {id}");
                Console.WriteLine($"Category: {addedTrainingPlan.Category}");
                Console.WriteLine($"Day: {addedTrainingPlan.Day}");
                Console.WriteLine($"Exercises: {addedTrainingPlan.NamesExercises}");
                Console.WriteLine($"Sets: {addedTrainingPlan.Sets}");
                Console.WriteLine($"Repetitions: {addedTrainingPlan.Repetitions}");

                Console.WriteLine("Do you want to add another Training Plan? (yes/no): ");
                string response = Console.ReadLine();
                if (response?.ToLower() != "yes")
                {
                    addTrainingPlan = false;
                }
            }
        }
        public void RemoveTrainingPlan()
        {
            Console.WriteLine("Enter the ID of the Training Plan to remove: ");
            int removeId;
            if (!int.TryParse(Console.ReadLine(), out removeId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            TrainingPlan trainingPlanToRemove = null;
            foreach (TrainingPlan trainingPlan in trainingPlansList)
            {
                if (trainingPlan.Id == removeId)
                {
                    trainingPlanToRemove = trainingPlan;
                    break;
                }
            }

            if (trainingPlanToRemove != null)
            {
                trainingPlansList.Remove(trainingPlanToRemove);
                Console.WriteLine($"Training Plan: {trainingPlanToRemove.Id} - {trainingPlanToRemove.NamesExercises}, {trainingPlanToRemove.Day} is removed!");
            }
            else
            {
                Console.WriteLine("Training Plan not found");
            }
        }

        public void ViewTrainingPlan()
        {
            if (trainingPlansList == null || trainingPlansList.Count == 0)
            {
                Console.WriteLine("No Training Plan found.");
            }
            else
            {
                foreach (var trainingPlan in trainingPlansList)
                {
                    Console.WriteLine(trainingPlan);
                }
            }
        }
        public void ModifyTrainingPlan()
        {
            Console.WriteLine("Enter the ID of the Training Plan to modify: ");
            int id = int.Parse(Console.ReadLine());

            TrainingPlan trainingPlan = trainingPlansList.FirstOrDefault(x => x.Id == id);

            if (trainingPlan == null)
            {
                Console.WriteLine("Training Plan not found");
                return;
            }

            Console.WriteLine($"Current Day: {trainingPlan.Day}. Enter new Day (or press Enter to keep current): ");
            string newDay = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDay))
            {
                trainingPlan.Day = newDay;
            }

            Console.WriteLine($"Current exercises: {trainingPlan.NamesExercises}. Do you want to modify exercises? (yes/no): ");
            string modifyExercisesResponse = Console.ReadLine();
            if (modifyExercisesResponse?.ToLower() == "yes")
            {
                string[] exercisesArray = trainingPlan.NamesExercises.Split(',');
                List<string> exercises = new List<string>();

                foreach (string exercise in exercisesArray)
                {
                    exercises.Add(exercise.Trim());
                }

                for (int i = 0; i < exercises.Count; i++)
                {
                    Console.WriteLine($"Current Exercise {i + 1}: {exercises[i]}. Enter new Exercise (or press Enter to keep current): ");
                    string newExercise = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newExercise))
                    {
                        exercises[i] = newExercise;
                    }
                }

                trainingPlan.NamesExercises = string.Join(", ", exercises);
            }
            Console.WriteLine($"Current Category: {trainingPlan.Category}. Enter new Category (or press Enter to keep current): ");
            string newcategory = Console.ReadLine();
            if (!string.IsNullOrEmpty(newcategory))
            {
                trainingPlan.Category = newcategory;
            }
            Console.WriteLine($"Current Sets: {trainingPlan.Sets}. Enter new Sets (or press Enter to keep current): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out int newSets))
                {
                    trainingPlan.Sets = newSets;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }
            Console.WriteLine($"Current Repetitions: {trainingPlan.Repetitions}. Enter new Repetitions (or press Enter to keep current): ");
            string input1 = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input1))
            {
                if (int.TryParse(input, out int newRepetitions))
                {
                    trainingPlan.Sets = newRepetitions;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }
        }
    }
}
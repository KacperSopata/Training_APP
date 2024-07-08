using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_APP;

namespace Training_APP
{
    public class ExerciseService
    {
        private List<Exercise> exerciseList = new List<Exercise>();

        public void AddExercise()
        {
            bool addedexercises1 = true;
            while (addedexercises1)
            {
                Console.WriteLine("Insert the category of the training: Push, Pull, Legs");
                string category = Console.ReadLine();
                Console.WriteLine("Insert the training day: ");
                string day = Console.ReadLine();
                Console.WriteLine("Insert the name of the training: ");
                string name = Console.ReadLine();
                Console.WriteLine("Insert how many sets: ");
                int sets = int.Parse(Console.ReadLine());
                Console.WriteLine("Insert how many repetitions: ");
                int repetitions = int.Parse(Console.ReadLine());
                Console.WriteLine("Specify by weight(kg): ");
                int weight = int.Parse(Console.ReadLine());
                int id = exerciseList.Count + 1;
                Exercise addedexercises = new Exercise(id, category, day, name, sets, repetitions, weight);
                exerciseList.Add(addedexercises);
                Console.WriteLine($"Exercises added succesfully. It' s id = {id}");
                Console.WriteLine($"Day: {addedexercises.Day}");
                Console.WriteLine($"Name: {addedexercises.Name}");
                Console.WriteLine($"Sets: {addedexercises.Sets}");
                Console.WriteLine($"Repetitions: {addedexercises.Repetitions}");
                Console.WriteLine($"Weight: {addedexercises.Weight}");
                Console.WriteLine($"Category: {addedexercises.Category}");
                Console.WriteLine("Do you want to add another exercise? (yes/no): ");
                string response = Console.ReadLine();
                if (response?.ToLower() != "yes")
                {
                    addedexercises1 = false;
                }
            }
        }
        public void RemoveExercise()
        {
            Console.WriteLine("Enter the ID of the exercise to remove: ");
            int removeId = int.Parse(Console.ReadLine());
            Exercise exerciseToRemove = null;
            foreach (Exercise exercise in exerciseList)
            {
                if (exercise.Id == removeId)
                {
                    exerciseToRemove = exercise;
                    break;
                }
            }
            if (exerciseToRemove != null)
            {
                exerciseList.Remove(exerciseToRemove);
                Console.WriteLine($"Exercise {exerciseToRemove.Id} - {exerciseToRemove.Name}, {exerciseToRemove.Day} is removed!");
            }
            else
            {
                Console.WriteLine("Exercise not found");
            }
        }
        public void ModifyExerise()
        {
            Console.WriteLine("Enter the ID of the exercise to modify: ");
            int newId;
            if (!int.TryParse(Console.ReadLine(), out newId))
            {
                Console.WriteLine("Invalid input. ID must be a valid integer.");
                return;
            }
            Exercise exercise = exerciseList.FirstOrDefault(e => e.Id == newId);
            if (exercise == null)
            {
                Console.WriteLine("Exercise not found.");
                return;
            }
            Console.WriteLine($"Current Day: {exercise.Day}. Enter new Name (or press Enter to keep current): ");
            string newDay = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDay))
            {
                exercise.Day = newDay;
            }
            Console.WriteLine($"Current Name: {exercise.Name}. Enter new Name (or press Enter to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                exercise.Name = newName;
            }
            Console.WriteLine($"Current Sets: {exercise.Sets}. Enter new Sets (or press Enter to keep current): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out int newSets))
                {
                    exercise.Sets = newSets;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }

            Console.WriteLine($"Current Repetitions: {exercise.Repetitions}. Enter new Repetitions (or press Enter to keep current): ");
            string input1 = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input1))
            {
                if (int.TryParse(input1, out int newRepetitions))
                {
                    exercise.Sets = newRepetitions;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }

            Console.WriteLine($"Current Weight: {exercise.Weight}. Enter new Weight (or press Enter to keep current): ");
            string input2 = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input2))
            {
                if (int.TryParse(input2, out int newWeight))
                {
                    exercise.Sets = newWeight;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }
        }
        public void ViewExercies()
        {
            if (exerciseList == null || exerciseList.Count == 0)
            {
                Console.WriteLine("No exercises found.");
            }
            else
            {
                foreach (var exercises in exerciseList)
                {
                    Console.WriteLine(exercises);
                }
            }
        }
        public void SearchExerciseByName()
        {

            Console.WriteLine("Enter the name of the exercises: ");
            string name = Console.ReadLine();
            bool found = false;
            foreach (var exercises in exerciseList)
            {
                if (exercises.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Exercises: {exercises.Name}, Day: {exercises.Day}, Sets: {exercises.Sets}, Repetitions: {exercises.Repetitions}, Weight {exercises.Weight} ");
                    exercises.ToString();
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No Exercises found for the specified name.");
            }
        }
        public void SearchExerciseByDay()
        {
            Console.WriteLine("Enter the Day of the exercises: ");
            string day = Console.ReadLine();
            bool found = false;

            foreach (var exercises in exerciseList)
            {
                if (exercises.Day.Equals(day, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Exercises on {exercises.Day}:");
                    Console.WriteLine(exercises.ToString());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No Exercises found for the specified day.");
            }
        }
        public void SearchExerciseByCategory()
        {
            Console.WriteLine("Enter the category of the exercises: ");

            string category = Console.ReadLine();
            bool found = false;

            foreach (var exercises in exerciseList)
            {
                if (exercises.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Exercises on {exercises.Category}:");
                    Console.WriteLine(exercises.ToString());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No Exercises found for the specified category.");
            }
        }

        public void FindReadyExercise()
        {
            Console.WriteLine("\nFind Ready Exercise");
            ExercisesService exercisesService = new ExercisesService();
            List<string> readyExercises = exercisesService.GetReadyExercises();
            for (int i = 0; i < readyExercises.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {readyExercises[i]}");
            }

            Console.Write("Enter the number of the exercise you want to select: ");
            string selectionInput = Console.ReadLine();
            int selection;
            while (!int.TryParse(selectionInput, out selection) || selection < 1 || selection > readyExercises.Count)
            {
                Console.Write("Invalid input. Please enter a valid number: ");
                selectionInput = Console.ReadLine();
            }

            string selectedExercise = readyExercises[selection - 1];
            exercisesService.SelectReadyExercise(selectedExercise);

            Console.WriteLine($"You have selected the exercise: {selectedExercise}");
        }
    }

    public class ExercisesService
    {
        private List<string> readyExercises;

        public ExercisesService()
        {
            readyExercises = new List<string>
        {
            "Push",
            "Pull",
            "Legs",
            "Cardio",
        };
        }

        public List<string> GetReadyExercises()
        {
            
            return readyExercises;
        }
        public void ShowExerciseDetails(string readyExercises)
        {
            switch (readyExercises)
            {
                case "Push":
                    Console.WriteLine("Push workout: \n1.Day: Monday. \n2.Exercises: Bench Press, Incline bench press,Triceps Curls, Shoulder press. \n3.Sets: 4 Sets.\n4.Repetitions: 12 Repetitions.");
                    break;
                case "Pull":
                    Console.WriteLine("Pull workout: \n1.Day: Tuesday. \n2.Exercises: Deadlifts, Pull-ups, Bicep Curls, Shoulder press.\n3.Sets: 4 Sets. \n4.Repetitions: 12 Repetitions.");
                    break;
                case "Legs":
                    Console.WriteLine("Legs workout: \n1.Day: Friday. \n2.Exercises: Lunges, Leg Press, Squats. \n3.Sets: 4 Sets. \n4.Repetitions: 12 Repetitions.");
                    break;
                case "Cardio":
                    Console.WriteLine("Cardio workout: \n1.Day: Saturday. \n2.Exercises: Cycling, Running or  Jump Rope. \n3.Sets: 4 Sets.\n4.Repetitions: 12 Repetitions.");
                    break;
                default:
                    Console.WriteLine("No details available for this workout.");
                    break;
            }
        }
        public void SelectReadyExercise(string readyExercises)
        {
            Console.WriteLine($"Selected ready exercise: {readyExercises}");
            ShowExerciseDetails(readyExercises);
        }
    }
}
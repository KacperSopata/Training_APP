using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_APP
{
    public class MealService
    {
        private List<Meal> mealsList = new List<Meal>();

        public void AddMeal()
        {
            bool addmeal = true;
            while (addmeal)
            {
                Console.WriteLine("Insert the name of the meal: ");
                string name = Console.ReadLine();
                Console.WriteLine("Insert how many kcal: ");
                int kcal = int.Parse(Console.ReadLine());
                Console.WriteLine("Insert how many protein: ");
                int protein = int.Parse(Console.ReadLine());
                Console.WriteLine("Insert how many fat: ");
                int fat = int.Parse(Console.ReadLine());
                Console.WriteLine("Insert how many carbo: ");
                int carbo = int.Parse(Console.ReadLine());
                int id = mealsList.Count + 1;
                Meal addedmeal = new Meal(id, name, kcal, protein, fat, carbo);
                mealsList.Add(addedmeal);
                Console.WriteLine($"Meal added succesfully. It' s id = {id}.");
                Console.WriteLine("Do you want to add another Meal? (yes/no): ");
                string response = Console.ReadLine();
                if (response?.ToLower() != "yes")
                {
                    addmeal = false;
                }
            }
        }
        public void RemoveMeal()
        {
            Console.WriteLine("Enter the ID of the Training Plan to remove: ");
            int removeId = int.Parse(Console.ReadLine());
            Meal mealToRemove = null;
            foreach (Meal trainingPlan in mealsList)
            {
                mealToRemove = trainingPlan;
                break;
            }
            if (mealToRemove != null)
            {
                mealsList.Remove(mealToRemove);
                Console.WriteLine($"Exercise {mealToRemove.ID} - {mealToRemove.Name} is removed!");
            }
            else
            {
                Console.WriteLine("Exercise not found");
            }
        }
        public void ViewMeal()
        {
            if (mealsList == null || mealsList.Count == 0)
            {
                Console.WriteLine("No meal found.");
            }
            else
            {
                foreach (var trainingPlan in mealsList)
                {
                    Console.WriteLine(trainingPlan);
                }
            }
        }
        public void ModifyMeal()
        {
            Console.WriteLine("Enter the ID of the meal to modify: ");
            int id = int.Parse(Console.ReadLine());
            Meal meal = null;

            foreach (var plan in mealsList)
            {
                if (plan.ID == id)
                {
                    meal = plan;
                    break;
                }
            }

            if (meal == null)
            {
                Console.WriteLine("Meal not found");
                return;
            }
            Console.WriteLine($"Current Name: {meal.Name}. Enter new Name (or press Enter to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                meal.Name = newName;
            }
            Console.WriteLine($"Current Kcal: {meal.Kcal}. Enter new Kcal (or press Enter to keep current): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out int newKcal))
                {
                    meal.Kcal = newKcal;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }
            Console.WriteLine($"Current Protein: {meal.Protein}. Enter new Protein (or press Enter to keep current): ");
            string input1 = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input1))
            {
                if (int.TryParse(input, out int newProtein))
                {
                    meal.Protein = newProtein;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }
            Console.WriteLine($"Current Fat: {meal.Fat}. Enter new Fat (or press Enter to keep current): ");
            string input2 = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input2))
            {
                if (int.TryParse(input, out int newFat))
                {
                    meal.Carbo = newFat;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }
            Console.WriteLine($"Current Carbo: {meal.Carbo}. Enter new Carbo (or press Enter to keep current): ");
            string input3 = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input3))
            {
                if (int.TryParse(input, out int newCarbo))
                {
                    meal.Carbo = newCarbo;
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }
        }
    }
}
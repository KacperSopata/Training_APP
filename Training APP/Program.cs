

namespace Training_APP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome tu our Fitness APP");
            ExerciseService exerciseService = new ExerciseService();
            TrainingPlanService trainingPlanService = new TrainingPlanService();
            MealService mealService = new MealService();
            MenuActionService menuActionService = new MenuActionService();
            menuActionService = Initialize(menuActionService);
            bool runing = true;
            while (runing)
            {
                Console.WriteLine("\nPlease let me know what you want to do:");
                menuActionService.MenuService();
                string selectedMenuCategory = Console.ReadLine();
                int resultMenuCategory;
                Int32.TryParse(selectedMenuCategory, out resultMenuCategory);
                switch (resultMenuCategory)
                {
                    case 1:
                        exerciseService.AddExercise();
                        break;
                    case 2:
                        exerciseService.RemoveExercise();
                        break;
                    case 3:
                        exerciseService.ModifyExerise();
                        break;
                    case 4:
                        exerciseService.ViewExercies();
                        break;
                    case 5:
                        exerciseService.SearchExerciseByName();
                        break;
                    case 6:
                        exerciseService.SearchExerciseByDay();
                        break;
                    case 7:
                        exerciseService.SearchExerciseByCategory();
                        break;
                    case 8:
                        exerciseService.FindReadyExercise();
                        break;
                    case 9:
                        trainingPlanService.AddTrainnigPlan();
                        break;
                    case 10:
                        trainingPlanService.RemoveTrainingPlan();
                        break;
                    case 11:
                        trainingPlanService.ViewTrainingPlan();
                        break;
                    case 12:
                        trainingPlanService.ModifyTrainingPlan();
                        break;
                    case 13:
                        mealService.AddMeal();
                        break;
                    case 14:
                        mealService.RemoveMeal();
                        break;
                    case 15:
                        mealService.ViewMeal();
                        break;
                    case 16:
                        mealService.ModifyMeal();
                        break;
                    case 17:
                        Console.WriteLine("Thank you for using our Training App!");
                        runing = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect method selected");
                        break;
                }
            }
        }
        public static MenuActionService Initialize(MenuActionService menuAction)
        {
            menuAction.AddNewAction(1, "Add Exercise.");
            menuAction.AddNewAction(2, "Remove Exercise.");
            menuAction.AddNewAction(3, "Modify Exerise.");
            menuAction.AddNewAction(4, "View Exercies.");
            menuAction.AddNewAction(5, "Search Exercise By Name.");
            menuAction.AddNewAction(6, "Search Exercise By Day.");
            menuAction.AddNewAction(7, "Search Exercise By Category.");
            menuAction.AddNewAction(8, "Find Ready Exercise.");
            menuAction.AddNewAction(9, "Add Trainnig Plan.");
            menuAction.AddNewAction(10, "Remove Training Plan.");
            menuAction.AddNewAction(11, "View Training Plan.");
            menuAction.AddNewAction(12, "Modify Training Plan.");
            menuAction.AddNewAction(13, "Add Meal.");
            menuAction.AddNewAction(14, "Remove Meal.");
            menuAction.AddNewAction(15, "View Meal.");
            menuAction.AddNewAction(16, "Modify Meal.");
            menuAction.AddNewAction(17, "Exit.");
            return menuAction;
        }
    }
}
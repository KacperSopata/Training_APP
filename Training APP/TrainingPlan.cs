using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_APP
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Day { get; set; }
        public string NamesExercises { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }

        public TrainingPlan(int id, string category, string day, string namesexercises, int sets, int repetitions)
        {
            Id = id;
            Category = category;
            Day = day;
            NamesExercises = namesexercises;
            Sets = sets;
            Repetitions = repetitions;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Category: {Category}, Day: {Day}, NamesExercises: {NamesExercises}, Sets: {Sets}, Repetitions: {Repetitions}. ";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_APP
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Day { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }

        public Exercise(int id, string category, string day, string name, int sets, int repetitions, int weight)
        {
            Id = id;
            Category = category;
            Day = day;
            Name = name;
            Sets = sets;
            Repetitions = repetitions;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Category: {Category}, Day: {Day},  Name: {Name},  Sets: {Sets}, Repetitions: {Repetitions}, Weight: {Weight} kg.";
        }
    }
}
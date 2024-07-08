using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_APP
{
    public class Meal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Kcal { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbo { get; set; }

        public Meal(int iD, string name, int kcal, int protein, int fat, int carbo)
        {
            ID = iD;
            Name = name;
            Kcal = kcal;
            Protein = protein;
            Fat = fat;
            Carbo = carbo;
        }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Kcal: {Kcal}, Protein: {Protein}, Fat: {Fat}, Carbo: {Carbo}.";
        }
    }
}

using System.Security.Principal;
using AthleteManagementTools.Interfaces;

namespace AthleteManagementTools.Model
{
    public class WeightClass : IWeightClass
    {
        public string Name { get; set; }
        public double OneRepMax { get; set; }
        public double ThreeRep { get; set; }
        public double FiveRep { get; set; }

        public WeightClass(string className, double oneRm)
        {
            Name = className;
            OneRepMax = oneRm;
            ThreeRep = FindThreeRep();
            FiveRep = FindFiveRep();
        }

        private double FindThreeRep()
        {
            return 0.9 * OneRepMax;
        }

        private double FindFiveRep()
        {
            return 0.85 * OneRepMax;
        }
    }
}
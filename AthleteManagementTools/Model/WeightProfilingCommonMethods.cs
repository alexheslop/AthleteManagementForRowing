using System.Collections.ObjectModel;

namespace AthleteManagementTools.Model
{
    public static class WeightProfilingCommonMethods
    {
        public static ObservableCollection<WeightClass> AddStandardClasses(double bodyweight)
        {
            var classList = new ObservableCollection<WeightClass>();
            var newClass = new WeightClass("Deadlift", 2*bodyweight);
            classList.Add(newClass);
            newClass = new WeightClass("Back Squat", 1.8 * bodyweight);
            classList.Add(newClass);
            newClass = new WeightClass("Front Squat", 1.8 * 0.85 * bodyweight);
            classList.Add(newClass);
            newClass = new WeightClass("Power Clean", 0.68 * 1.8 * bodyweight);
            classList.Add(newClass);
            newClass = new WeightClass("Bench Pull", 1.4 * bodyweight);
            classList.Add(newClass);
            return classList;
        }
    }
}
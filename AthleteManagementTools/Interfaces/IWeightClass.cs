namespace AthleteManagementTools.Interfaces
{
    public interface IWeightClass
    {
        string Name { get; set; }
        double OneRepMax { get; set; }
        double ThreeRep { get; set; }
        double FiveRep { get; set; }
    }
}
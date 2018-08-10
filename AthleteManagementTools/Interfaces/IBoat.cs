namespace AthleteManagementTools.Interfaces
{
    public interface IBoat
    {
        string BoatName { get; set; }
        int Seats { get; set; }
        bool Scull { get; set; }
        bool Cox { get; set; }
        int ClassRank { get; set; }
    }
}
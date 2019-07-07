using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class AddBoatViewModel
    {
        public Boat NewBoat { get; set; }
        public AddBoatViewModel()
        {
            NewBoat = new Boat();
        }

        public void AddBoatToCollection()
        {
            SqlServerDbComms.WriteBoatToDatabase(NewBoat.BoatName, NewBoat.Seats, NewBoat.Cox, NewBoat.Scull,
                NewBoat.ClassRank);
        }
    }
}
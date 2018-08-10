using AthleteManagementTools.Interfaces;

namespace AthleteManagementTools.Model
{
    public class Boat : IBoat
    {
        public string BoatName { get; set; }
        public int Seats { get; set; }
        public bool Scull { get; set; }
        public bool Cox { get; set; }
        public int ClassRank { get; set; }

        public Boat()
        {
            Initialise("",0,false,false,0);
        }

        public void Initialise(string name, int seats, bool scull, bool cox, int classRank)
        {
            BoatName = name;
            Seats = seats;
            Scull = scull;
            Cox = cox;
            ClassRank = classRank;
        }
    }
}
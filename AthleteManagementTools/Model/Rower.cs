using AthleteManagementTools.Interfaces;

namespace AthleteManagementTools.Model
{
    public class Rower:IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Squad { get; set; }
        public string Side { get; set; }
        public bool CanScull { get; set; }
        public double ErgTime { get; set; }
        public int StrokesideRank { get; set; }
        public int BowsideRank { get; set; }
        public int ScullRank { get; set; }

        public Rower()
        {
            FirstName = "New";
            LastName = "Rower";
            Squad = "Senior Women";
            Side = "Strokeside";
            CanScull = true;
            ErgTime = 400;
            StrokesideRank = 0;
            BowsideRank = 0;
            ScullRank = 0;
        }
    }
}
using AthleteManagementTools.Interfaces;

namespace AthleteManagementTools.Model
{
    public class Rower:IRower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Squad { get; set; }
        public string Side { get; set; }
        public bool CanScull { get; set; }
        public int StrokesideRank { get; set; }
        public int BowsideRank { get; set; }
        public int ScullRank { get; set; }
        public string Pb2K { get; set; }
        public string Pb5K { get; set; }
        public string Pb30R20 { get; set; }
        public string Ut2Split { get; set; }
        public int MaxHr { get; set; }
        public int MinHr { get; set; }
        public bool Injured { get; set; }

        public Rower()
        {
            FirstName = "New";
            LastName = "Rower";
            Squad = "Senior Women";
            Side = "Strokeside";
            CanScull = true;
            StrokesideRank = 0;
            BowsideRank = 0;
            ScullRank = 0;
            Pb2K = "7:00.0";
            Pb5K = "20:00.0";
            Pb30R20 = "1:50.0";
            Ut2Split = "2:00.0";
            MaxHr = 200;
            MinHr = 60;
            Injured = false;
        }
    }
}
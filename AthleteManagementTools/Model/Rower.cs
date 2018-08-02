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

        public Rower(string firstName, string lastName, string squad)
        {
            FirstName = firstName;
            LastName = lastName;
            Squad = squad;
        }
    }
}
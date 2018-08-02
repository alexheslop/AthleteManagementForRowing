namespace AthleteManagementTools.Interfaces
{
    public interface IRower :IPerson
    {
        string Side { get; set; }
        bool CanScull { get; set; }
        double ErgTime { get; set; }
        int StrokesideRank { get; set; }
        int BowsideRank { get; set; }
        int ScullRank { get; set; }
    }
}
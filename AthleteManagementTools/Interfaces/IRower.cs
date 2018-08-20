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
        string Pb2K { get; set; }
        string Pb5K { get; set; }
        string Pb30R20 { get; set; }
        string Ut2Split { get; set; }
        int MaxHr { get; set; }
        int MinHr { get; set; }
    }
}
namespace AthleteManagementTools.Model
{
    public class TrainingZone
    {
        public string ZoneName { get; set; }
        public double Watts { get; set; }
        public string Split { get; set; }
        public double HrLower { get; set; }
        public double HrUpper { get; set; }

        public TrainingZone(string zoneName, double watts, string split, double hRLower, double hRUpper)
        {
            ZoneName = zoneName;
            Watts = watts;
            Split = split;
            HrLower = hRLower;
            HrUpper = hRUpper;
        }
    }
}
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class EditRowerViewModel
    {
        public Rower NewRower { get; set; }

        public EditRowerViewModel(object rower)
        {
            NewRower = (Rower) rower;
        }

        public bool UpdatePersonInDatabase()
        {
            AccessDatabaseComms.UpdateRowerFromDetails(NewRower.FirstName, NewRower.LastName, NewRower.Squad, NewRower.Side,
                NewRower.CanScull, NewRower.BowsideRank, NewRower.StrokesideRank, NewRower.ScullRank, NewRower.Injured);
            return true;
        }
    }
}
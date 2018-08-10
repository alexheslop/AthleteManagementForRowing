using AthleteManagementTools.Model;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace AthleteManagementTools.ViewModel
{
    public class AddPersonViewModel
    {
        public Rower NewRower { get; set; }
        public Coxswain NewCoxswain { get; set; }
        public AddPersonViewModel()
        {
            NewRower = new Rower();
            NewCoxswain = new Coxswain();
        }

        public bool AddPersonToDatabase()
        {
            AccessDatabaseComms.WritePersonToDatabase(NewRower.FirstName, NewRower.LastName, NewRower.Squad, NewRower.Side,
                NewRower.CanScull, NewRower.BowsideRank, NewRower.StrokesideRank, NewRower.ScullRank, NewRower.ErgTime);
            return true;
        }
    }
}
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class AddPersonViewModel
    {
        public Rower newRower { get; set; }
        public Coxswain newCoxswain { get; set; }
        public AddPersonViewModel()
        {
            newRower = new Rower("default", "rower");
            newCoxswain = new Coxswain("default","coxswain");
        }
    }
}
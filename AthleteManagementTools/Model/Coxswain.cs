namespace AthleteManagementTools.Model
{
    public class Coxswain:IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Squad { get; set; }

        public Coxswain(string firstName, string lastName, string squad)
        {
            FirstName = firstName;
            LastName = lastName;
            Squad = squad;
        }
    }
}
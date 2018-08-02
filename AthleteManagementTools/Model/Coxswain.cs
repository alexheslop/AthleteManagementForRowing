﻿using AthleteManagementTools.Interfaces;

namespace AthleteManagementTools.Model
{
    public class Coxswain:IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Squad { get; set; }

        public Coxswain(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
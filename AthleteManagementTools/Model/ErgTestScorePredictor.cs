using System;

namespace AthleteManagementTools.Model
{
    public static class ErgTestScorePredictor
    {
        public static double Expected5KScore(double Watts2K)
        {
            var score = Watts2K * 0.82;
            return score;
        }

        public static double Expected30r20Score(double Watts2K)
        {
            var score = Watts2K*0.73;
            return score;
        }
        
        

    }
}
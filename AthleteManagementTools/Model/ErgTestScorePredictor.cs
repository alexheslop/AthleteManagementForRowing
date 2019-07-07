namespace AthleteManagementTools.Model
{
    public static class ErgTestScorePredictor
    {
        public static double Expected5KScore(double watts2K)
        {
            var score = watts2K * 0.82101;
            return score;
        }

        public static double Expected30R20Score(double watts2K)
        {
            var score = watts2K*0.7;
            return score;
        }

        public static double ExpectedUt2(double watts2K)
        {
            var score = watts2K * 0.55867;
            return score;
        }

        public static double Expected2Kfrom5KScore(double watts2K)
        {
            var score = watts2K / 0.82;
            return score;
        }

        public static double Expected2Kfrom30R20Score(double watts2K)
        {
            var score = watts2K / 0.7;
            return score;
        }



    }
}
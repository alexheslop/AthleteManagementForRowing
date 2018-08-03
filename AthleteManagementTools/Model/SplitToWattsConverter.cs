using System;

namespace AthleteManagementTools.Model
{
    public static class SplitToWattsConverter
    {
        public static double SplitToWattsConvert(double split)
        {
            var watts = Math.Round(2.8 /Math.Pow(split/500,3),MidpointRounding.AwayFromZero);

            return watts;
        }

        public static double WattsToSplitConvert(double watts)
        {
            var split = Math.Round(500* Math.Pow(2.8/watts, (float) 1/3),1,MidpointRounding.AwayFromZero);

            return split;
        }
    }
}
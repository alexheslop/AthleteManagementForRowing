using System;

namespace AthleteManagementTools.Model
{
    public static class TimeToSplitConverter
    {
        public static string ConvertSecondsToSplit(double seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string str = time.ToString(@"m\:ss\.f");
            
            return str;
        }

        public static double ConvertSplitToSeconds(string split)
        {
            var time = DateTime.ParseExact(split, "m:ss.f", null);
            var minutesToSeconds = time.Minute * 60;
            var seconds = time.Second;
            var milliToSeconds = (double) time.Millisecond / 1000;
            var total = minutesToSeconds + seconds + milliToSeconds;

            return total;
        }
    }
}
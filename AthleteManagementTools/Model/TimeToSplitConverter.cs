using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AthleteManagementTools.Model
{
    public static class TimeToSplitConverter
    {
        public static string ConvertSecondsToSplit(double seconds)
        {
            if (double.IsInfinity(seconds))
            {
                return "00:00.0";
            }
            var time = TimeSpan.FromSeconds(seconds);
            var str = time.ToString(@"m\:ss\.f");
            
            return str;
        }

        public static double ConvertSplitToSeconds(string split)
        {
            double total = 0;
            try
            {
                var time = DateTime.ParseExact(split, "m:ss.f", null);
                var minutesToSeconds = time.Minute * 60;
                var seconds = time.Second;
                var milliToSeconds = (double) time.Millisecond / 1000;
                total = minutesToSeconds + seconds + milliToSeconds;
            }
            catch (FormatException)
            {
                total = 0;
                MessageBox.Show("Please enter a time or split in the format 'mm:ss.0'");
            }
            return total;



        }
    }
}
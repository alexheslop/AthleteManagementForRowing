using System;
using System.Collections.ObjectModel;

namespace AthleteManagementTools.Model
{
    public class SplitCalculator
    {
        public readonly ObservableCollection<TrainingZone> TrainingZoneList;
        private readonly double _hrMin;
        private readonly double _hrReserve;
        private readonly string _ut2Split;
        private readonly double _2KWatts;
        
        public SplitCalculator(double hrMax, double hrMin, string ut2Split)
        {
            _ut2Split = ut2Split;
            _hrMin = hrMin;
            _hrReserve = hrMax - _hrMin;
            var ut2Seconds = TimeToSplitConverter.ConvertSplitToSeconds(ut2Split);
            _2KWatts = SplitToWattsConverter.SplitToWattsConvert(ut2Seconds)/0.6;
            TrainingZoneList = new ObservableCollection<TrainingZone> {GetUt2(), GetUt1(), GetAt(), GetTr(), GetAn() };
        }
        
        private TrainingZone GetUt2()
        {
            var ut2MinHr = Math.Round(_hrMin + (0.6 * _hrReserve), MidpointRounding.AwayFromZero);
            var ut2MaxHr = Math.Round(_hrMin + (0.7 * _hrReserve), MidpointRounding.AwayFromZero);
            var ut2Watts = Math.Round(_2KWatts * 0.6, MidpointRounding.AwayFromZero);
            var ut2Zone = new TrainingZone("UT2", ut2Watts, _ut2Split, ut2MinHr, ut2MaxHr);
            return ut2Zone;
        }

        private TrainingZone GetUt1()
        {
            var ut1MinHr = Math.Round(_hrMin + (0.7 * _hrReserve), MidpointRounding.AwayFromZero);
            var ut1MaxHr = Math.Round(_hrMin + (0.8 * _hrReserve), MidpointRounding.AwayFromZero);
            var ut1Watts = Math.Round(_2KWatts * 0.7, MidpointRounding.AwayFromZero);
            var ut1Split = TimeToSplitConverter.ConvertSecondsToSplit(SplitToWattsConverter.WattsToSplitConvert(ut1Watts));
            var ut1Zone = new TrainingZone("UT1", ut1Watts, ut1Split, ut1MinHr, ut1MaxHr);
            return ut1Zone;
        }

        private TrainingZone GetAt()
        {
            var atMinHr = Math.Round(_hrMin + (0.8 * _hrReserve), MidpointRounding.AwayFromZero);
            var atMaxHr = Math.Round(_hrMin + (0.85 * _hrReserve), MidpointRounding.AwayFromZero);
            var atWatts = Math.Round(_2KWatts * 0.8, MidpointRounding.AwayFromZero);
            var atSplit = TimeToSplitConverter.ConvertSecondsToSplit(SplitToWattsConverter.WattsToSplitConvert(atWatts));
            var atZone = new TrainingZone("AT", atWatts, atSplit, atMinHr, atMaxHr);
            return atZone;
        }

        private TrainingZone GetTr()
        {
            var trMinHr = Math.Round(_hrMin + (0.85 * _hrReserve), MidpointRounding.AwayFromZero);
            var trMaxHr = Math.Round(_hrMin + (0.95 * _hrReserve), MidpointRounding.AwayFromZero);
            var trWatts = Math.Round(_2KWatts * 1.05, MidpointRounding.AwayFromZero);
            var trSplit = TimeToSplitConverter.ConvertSecondsToSplit(SplitToWattsConverter.WattsToSplitConvert(trWatts));
            var trZone = new TrainingZone("TR", trWatts, trSplit, trMinHr, trMaxHr);
            return trZone;
        }

        private TrainingZone GetAn()
        {
            var anMinHr = Math.Round(_hrMin + (0.95 * _hrReserve), MidpointRounding.AwayFromZero);
            var anMaxHr = Math.Round(_hrMin + (1 * _hrReserve), MidpointRounding.AwayFromZero);
            var anWatts = Math.Round(_2KWatts * 1.15, MidpointRounding.AwayFromZero);
            var anSplit = TimeToSplitConverter.ConvertSecondsToSplit(SplitToWattsConverter.WattsToSplitConvert(anWatts));
            var anZone = new TrainingZone("AN", anWatts, anSplit, anMinHr, anMaxHr);
            return anZone;
        }

        public string Get5K()
        {
            var watts5K = ErgTestScorePredictor.Expected5KScore(_2KWatts);
            var split5K = TimeToSplitConverter.ConvertSecondsToSplit(SplitToWattsConverter.WattsToSplitConvert(watts5K));
            

            return split5K;
        }

        public string Get30R20()
        {
            var watts30R20 = ErgTestScorePredictor.Expected30r20Score(_2KWatts);
            var target30R20 = TimeToSplitConverter.ConvertSecondsToSplit(SplitToWattsConverter.WattsToSplitConvert(watts30R20));

            return target30R20;
        }

        public string Get2K()
        {
            var target2K = TimeToSplitConverter.ConvertSecondsToSplit(SplitToWattsConverter.WattsToSplitConvert(_2KWatts));

            return target2K;
        }

        public string Get5KTime()
        {
            var watts5K = ErgTestScorePredictor.Expected5KScore(_2KWatts);
            var time5K = TimeToSplitConverter.ConvertSecondsToSplit(10*SplitToWattsConverter.WattsToSplitConvert(watts5K));


            return time5K;
        }

        public string Get2KTime()
        {
            var target2K = TimeToSplitConverter.ConvertSecondsToSplit(4*SplitToWattsConverter.WattsToSplitConvert(_2KWatts));

            return target2K;
        }
    }
}
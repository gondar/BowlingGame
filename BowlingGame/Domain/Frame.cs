namespace BowlingGame.Domain
{
    public interface IFrame
    {
        int RollOne { get; }
        int RollTwo { get; }
        int GetScore(IFrame nextFrame);
    }

    public class Frame : IFrame
    {
        public int RollOne { get; set; }
        public int RollTwo { get; set; }
        public int RollThree { get; set; }

        public int GetScore(IFrame nextFrame)
        {
            if (RollOne == 10)
                return ComputeStrike(nextFrame);

            var frameSum = RollOne + RollTwo;

            if (frameSum == 10)
            {
                frameSum += nextFrame != null ? nextFrame.RollOne : RollThree;
            }
            return frameSum;
        }

        private int ComputeStrike(IFrame nextFrame)
        {
            if (nextFrame != null)
                return RollOne + nextFrame.RollOne + nextFrame.RollTwo;

            return RollOne + RollTwo + RollThree;
        }
    }
}
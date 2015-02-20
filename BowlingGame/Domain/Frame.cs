namespace BowlingGame.Domain
{
    public interface IFrame
    {
        int RollOne { get; }
        int RollTwo { get; }
        int RollThree { get; }
        int GetScore(IFrame nextFrame, IFrame thirdFrame);
    }

    public class Frame : IFrame
    {
        public int RollOne { get; set; }
        public int RollTwo { get; set; }
        public int RollThree { get; set; }

        public int GetScore(IFrame nextFrame, IFrame thirdFrame)
        {
            if (RollOne == 10)
                return ComputeStrike(nextFrame, thirdFrame);

            var frameSum = RollOne + RollTwo;

            if (frameSum == 10)
            {
                frameSum += nextFrame != null ? nextFrame.RollOne : RollThree;
            }
            return frameSum;
        }

        private int ComputeStrike(IFrame nextFrame, IFrame thirdFrame)
        {
            var nextRoll = GetNextRoll(nextFrame);
            var thirdRoll = GetThirdRoll(nextFrame, thirdFrame);

            return RollOne + nextRoll + thirdRoll;
        }

        private int GetNextRoll(IFrame nextFrame)
        {
            return nextFrame != null ? nextFrame.RollOne : RollTwo;
        }

        private int GetThirdRoll(IFrame nextFrame, IFrame thirdFrame)
        {
            if (nextFrame == null)
                return RollThree;

            if (nextFrame.RollOne == 10)
            {
                return thirdFrame != null ? thirdFrame.RollOne : nextFrame.RollTwo;
            }

            return nextFrame.RollTwo;
        }
    }
}
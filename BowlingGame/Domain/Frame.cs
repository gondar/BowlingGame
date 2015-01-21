namespace BowlingGame.Domain
{
    public interface IFrame
    {
        int RollOne { get; }
        int RollTwo { get; }
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
            if (nextFrame != null)
            {
                if (nextFrame.RollOne == 10)
                {
                    if (thirdFrame != null)
                        return RollOne + nextFrame.RollOne + thirdFrame.RollOne;
                    return RollOne + nextFrame.RollOne + nextFrame.RollTwo;
                }
                return RollOne + nextFrame.RollOne + nextFrame.RollTwo;   
            }
            return RollOne + RollTwo + RollThree;
        }
    }
}
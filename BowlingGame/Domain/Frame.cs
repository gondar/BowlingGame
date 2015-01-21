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

        public int GetScore(IFrame nextFrame)
        {
            var frameSum = RollOne + RollTwo;

            if (frameSum == 10)
            {
                frameSum += nextFrame.RollOne;
            }
            return frameSum;
        }
    }
}
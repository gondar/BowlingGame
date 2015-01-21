namespace BowlingGame.Domain
{
    public class Frame
    {
        public int RollOne { get; set; }
        public int RollTwo { get; set; }

        public int GetScore(Frame nextFrame)
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
using System;
using BowlingGame.Domain;

namespace BowlingGame.UI
{
    public interface IFrameParser
    {
        IFrame Parse(string frameText);
    }

    public class FrameParser : IFrameParser
    {
        public IFrame Parse(string frameText)
        {
            var frame = new Frame();

            var rolls = frameText.Trim().Split(' ');

            frame.RollOne = parseFirstRoll(rolls[0]);

            if (frame.RollOne != 10)
                frame.RollTwo = parseSecondRoll(rolls[1], frame.RollOne);

            return frame;
        }

        private int parseFirstRoll(string rollText)
        {
            if (isAllStandingPins(rollText))
                return 10;
            return int.Parse(rollText);
        }

        private int parseSecondRoll(string rollText, int roll1)
        {
            if (isAllStandingPins(rollText))
                return 10 - roll1;
            return int.Parse(rollText);
        }

        private bool isAllStandingPins(string rollText)
        {
            return rollText.Equals("/", StringComparison.Ordinal);
        }
    }
}

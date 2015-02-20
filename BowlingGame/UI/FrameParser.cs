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

            frame.RollOne = ParseRoll(rolls[0]);

            if (rolls.Length > 1)
                frame.RollTwo = ParseSecondRoll(rolls[1], frame.RollOne);

            if (rolls.Length > 2)
                frame.RollThree = ParseRoll(rolls[2]);

            return frame;
        }

        private int ParseRoll(string rollText)
        {
            if (IsAllStandingPins(rollText))
                return 10;
            return int.Parse(rollText);
        }

        private int ParseSecondRoll(string rollText, int roll1)
        {
            if (IsAllStandingPins(rollText))
                return 10 - roll1;
            return int.Parse(rollText);
        }

        private static bool IsAllStandingPins(string rollText)
        {
            return rollText.Equals("/", StringComparison.Ordinal);
        }
    }
}

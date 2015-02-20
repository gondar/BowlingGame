using System;
using BowlingGame.Domain;

namespace BowlingGame.UI
{
    public class FrameParser
    {
        public IFrame Parse(string frameText)
        {
            var frame = new Frame();

            var rolls = frameText.Trim().Split(' ');

            frame.RollOne = parseFirstRoll(rolls[0]);

            if (frame.RollOne != 10)
                frame.RollTwo = parseFirstRoll(rolls[1]);

            return frame;
        }

        private int parseFirstRoll(string roll)
        {
            if (roll.Equals("/", StringComparison.Ordinal))
                return 10;
            return int.Parse(roll);
        }
    }
}

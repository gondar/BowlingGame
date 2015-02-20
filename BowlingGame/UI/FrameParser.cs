using BowlingGame.Domain;

namespace BowlingGame.UI
{
    public class FrameParser
    {
        public IFrame Parse(string frameText)
        {
            var rolls = frameText.Trim().Split(' ');
            var roll1 = parseFirstRoll(rolls[0]);
            var roll2 = parseFirstRoll(rolls[1]);

            return new Frame()
            {
                RollOne = roll1,
                RollTwo = roll2
            };
        }

        private int parseFirstRoll(string roll)
        {
            return int.Parse(roll);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Domain
{
    public class Game
    {
        public int Play(GameState rolls)
        {
            var sum = 0;

            for (int i = 0; i < rolls.Frames.Count; i++)
            {
                var frame = rolls.Frames[i];
                var frameSum = frame.RollOne + frame.RollTwo;
                if (frameSum == 10)
                {
                    //spare
                    var nextFrame = rolls.Frames[i + 1];
                    frameSum += nextFrame.RollOne;
                }
                sum += frameSum;

            }

            return sum;
        }
    }

    public class GameState
    {
        public List<Frame> Frames { get; set; }
    }

    public class Frame
    {
        public int RollOne { get; set; }
        public int RollTwo { get; set; }
    }
}

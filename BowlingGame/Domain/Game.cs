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
            return rolls.Frames.Sum(frame => frame.RollOne+frame.RollTwo);
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

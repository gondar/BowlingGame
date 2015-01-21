using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Helpers;

namespace BowlingGame.Domain
{
    public class Game
    {
        public int Play(GameState rolls)
        {
            return rolls.Frames
                        .PairUp()
                        .Sum( pair => pair.Item1.GetScore(pair.Item2));
        }
    }
}

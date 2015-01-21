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
                        .GetTriples()
                        .Sum( tuple => tuple.Item1.GetScore(tuple.Item2, tuple.Item3));
        }
    }
}

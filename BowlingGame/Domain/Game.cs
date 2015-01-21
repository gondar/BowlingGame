﻿using System;
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
                var nextFrame = (i+1 < rolls.Frames.Count) ? rolls.Frames[i + 1] : null;
                var frameSum = frame.GetScore(nextFrame);

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

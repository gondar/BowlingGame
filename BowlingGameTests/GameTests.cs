using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Domain;
using NUnit.Framework;
using Shouldly;

namespace BowlingGameTests
{
    class GameTests
    {
        internal static Frame GetEmptyFrame()
        {
            return new Frame {RollOne = 0, RollTwo = 0};
        }

        [TestFixture]
        public class When_playing_game_with_no_pins_knocked
        {
            private int _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var subject = new Game();

                var rolls = new GameState { Frames = new List<Frame>() };

                for (var i = 0; i < 10; i++)
                {
                    rolls.Frames.Add(GetEmptyFrame());
                }

                _outcome = subject.Play(rolls);
            }

            [Test]
            public void should_return_zero()
            {
                _outcome.ShouldBe(0);
            }
        }
    }
}

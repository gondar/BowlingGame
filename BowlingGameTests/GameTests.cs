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
            return GetFrame(0,0);
        }

        internal static Frame GetFrame(int rollOne, int rollTwo)
        {
            return new Frame { RollOne = rollOne, RollTwo = rollTwo };
        }

        [TestFixture]
        public class When_playing_game_with_no_pins_knocked : With_Game
        {
            [TestFixtureSetUp]
            public void SetUp()
            {
                for (var i = 0; i < 10; i++)
                {
                    CurrentGameState.Frames.Add(GetEmptyFrame());
                }

                Outcome = Subject.Play(CurrentGameState);
            }

            [Test]
            public void should_return_zero()
            {
                Outcome.ShouldBe(0);
            }
        }

        [TestFixture]
        public class When_playing_game_with_only_one_pin_knocked_every_frame : With_Game
        {
            [TestFixtureSetUp]
            public void SetUp()
            {
                for (var i = 0; i < 10; i++)
                {
                    CurrentGameState.Frames.Add(GetFrame(0,1));
                }

                Outcome = Subject.Play(CurrentGameState);
            }

            [Test]
            public void should_return_ten()
            {
                Outcome.ShouldBe(10);
            }
        }

        [TestFixture]
        public class When_playing_game_with_first_spare_and_then_one_pin_every_roll : With_Game
        {
            [TestFixtureSetUp]
            public void SetUp()
            {
                CurrentGameState.Frames.Add(GetFrame(9, 1));
                for (var i = 0; i < 9; i++)
                {
                    CurrentGameState.Frames.Add(GetFrame(1, 1));
                }

                Outcome = Subject.Play(CurrentGameState);
            }

            [Test]
            public void should_return_with_bonus_for_spare()
            {
                Outcome.ShouldBe(11+9*2);
            }
        }

        internal class With_Game
        {
            protected Game Subject;
            protected GameState CurrentGameState;
            protected int Outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                Subject = new Game();

                CurrentGameState = new GameState { Frames = new List<Frame>() };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Domain;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace BowlingGameTests
{
    class GameTests
    {
        internal static IFrame GetFrame(int score)
        {
            var frame = Substitute.For<IFrame>();
            frame.GetScore(null).ReturnsForAnyArgs(score);
            return frame;
        }

        [TestFixture]
        public class When_playing_game : With_Game
        {
            [TestFixtureSetUp]
            public void SetUp()
            {
                for (var i = 0; i < 10; i++)
                {
                    CurrentGameState.Frames.Add(GetFrame(2));
                }

                Outcome = Subject.Play(CurrentGameState);
            }

            [Test]
            public void should_return_zero()
            {
                Outcome.ShouldBe(20);
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

                CurrentGameState = new GameState { Frames = new List<IFrame>() };
            }
        }
    }
}

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
            frame.GetScore(null, null).ReturnsForAnyArgs(score);
            return frame;
        }

        internal static IFrame GetFrame(int score, IFrame nextFrame)
        {
            var frame = Substitute.For<IFrame>();
            frame.GetScore(nextFrame, null).Returns(score);
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
            public void should_return_valid_outcome()
            {
                Outcome.ShouldBe(20);
            }
        }

        [TestFixture]
        public class When_playing_game_with_frames_depending_on_subsequent_frames : With_Game
        {
            private IFrame _frameAfterSpare;
            private IFrame _frameWithSpare;

            [TestFixtureSetUp]
            public void SetUp()
            {
                _frameAfterSpare = GetFrame(5);
                _frameWithSpare = GetFrame(15, _frameAfterSpare);

                CurrentGameState.Frames.Add(_frameWithSpare);
                CurrentGameState.Frames.Add(_frameAfterSpare);
                for (var i = 0; i < 8; i++)
                {
                    CurrentGameState.Frames.Add(GetFrame(1));
                }

                Outcome = Subject.Play(CurrentGameState);
            }

            [Test]
            public void should_return_valid_outcome()
            {
                Outcome.ShouldBe(28);
            }

            [Test]
            public void should_pass_next_frame()
            {
                _frameWithSpare.Received().GetScore(_frameAfterSpare, null);
            }
        }

        [TestFixture]
        public class When_playing_game_with_frame_depending_on_subsequent_frame_but_it_is_last_frame : With_Game
        {
            private IFrame _frameWithSpare;

            [TestFixtureSetUp]
            public void SetUp()
            {
                for (var i = 0; i < 9; i++)
                {
                    CurrentGameState.Frames.Add(GetFrame(1));
                }
                _frameWithSpare = GetFrame(15, null);
                CurrentGameState.Frames.Add(_frameWithSpare);

                Outcome = Subject.Play(CurrentGameState);
            }

            [Test]
            public void should_return_valid_outcome()
            {
                Outcome.ShouldBe(24);
            }

            [Test]
            public void should_pass_null_as_next_frame()
            {
                _frameWithSpare.Received().GetScore(null, null);
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

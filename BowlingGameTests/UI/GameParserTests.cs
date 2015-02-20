using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Domain;
using BowlingGame.UI;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace BowlingGameTests.UI
{
    class GameParserTests
    {
        [TestFixture]
        public class When_Parsing_Single_Game
        {
            private GameState _gameState;
            private IFrame _mockFrame;

            [TestFixtureSetUp]
            public void SetUp()
            {
                const string gameText = "1 0 | 2 1 | 3 1 | 4 1 | 5 1 | 6 1 | 7 1 | 8 1 | 9 1 | / 1 1 ";
                _mockFrame = new Frame {RollOne = 1, RollTwo = 0};
                var frameParser = Substitute.For<IFrameParser>();
                frameParser.Parse(null).ReturnsForAnyArgs(_mockFrame);
                var subject = new GameParser(frameParser);

                _gameState = subject.Parse(gameText);
            }

            [Test]
            public void should_create_game_state_with_10_frames()
            {
                _gameState.Frames.Count.ShouldBe(10);
            }

            [Test]
            public void should_have_mock_frame_for_each_frame()
            {
                _gameState.Frames.ForEach(frame => frame.ShouldBe(_mockFrame));
            }
        }
    }

    internal class GameParser
    {
        private readonly IFrameParser _frameParser;

        public GameParser(IFrameParser frameParser)
        {
            _frameParser = frameParser;
        }

        public GameState Parse(string gameText)
        {
            return new GameState
                {
                    Frames = gameText.Split('|')
                                     .Select(frame => _frameParser.Parse(frame))
                                     .ToList()
                };
        }
    }
}

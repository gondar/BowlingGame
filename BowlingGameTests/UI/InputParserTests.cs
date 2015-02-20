using System.Collections.Generic;
using BowlingGame.Domain;
using BowlingGame.UI;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace BowlingGameTests.UI
{
    class InputParserTests
    {
        [TestFixture]
        public class When_parsing_bowling_game_input
        {
            private List<GameState> _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var input = new List<string>
                    {
                        "game1",
                        "game2",
                        "game3"
                    };
                var gameParser = Substitute.For<IGameParser>();
                gameParser.Parse(null).ReturnsForAnyArgs(new GameState());
                var subject = new InputParser(gameParser);

                _outcome = subject.Parse(input);
            }

            [Test]
            public void should_return_list_of_games()
            {
                _outcome.Count.ShouldBe(3);
            }
        }
    }
}

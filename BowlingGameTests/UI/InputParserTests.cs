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
    class InputParserTests
    {
        [TestFixture]
        public class When_parsing_bowling_game_input
        {
            private List<GameState> _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                const string input = "game1\ngame2\ngame3\n";
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

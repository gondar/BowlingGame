using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.UI;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace BowlingGameAcceptanceTests
{
    public class BowlingGameTests
    {
        [TestFixture]
        public class When_running_multiple_bowling_games
        {
            private List<string> _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var consoleWrapper = Substitute.For<IConsoleWrapper>();
                consoleWrapper.ReadLines().Returns(new List<string>
                    {
                        "2 2 | 2 0 | 2 5 | 0 5 | 5 1 | 6 2 | 7 / | / | 2 1 | 1 1 ",
                        "/ | 1 1 | 2 3 | 1 5 | 6 0 | 0 0 | 0 0 | 0 0 | 0 0 | 0 0 ",
                        "/ | 1 1 | 2 3 | 1 5 | 6 0 | 0 0 | 0 0 | 0 0 | 0 0 | / 1 2 "
                    });
                consoleWrapper.WhenForAnyArgs(x=>x.WriteLines(null)).Do(call => _outcome = call.Arg<List<string>>());
                var subject = new BowlingGame.BowlingGame(consoleWrapper);

                subject.Play();
            }

            [Test]
            public void should_return_to_console_expected_output_of_first_game()
            {
                _outcome[0].ShouldBe("70");
            }

            [Test]
            public void should_return_to_console_expected_output_of_second_game()
            {
                _outcome[1].ShouldBe("31");
            }

            [Test]
            public void should_return_expected_output_three_element_game()
            {
                _outcome[2].ShouldBe("44");
            }
        }
    }
}

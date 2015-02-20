using BowlingGame.Domain;
using BowlingGame.UI;
using NUnit.Framework;
using Shouldly;

namespace BowlingGameTests.UI
{
    class FrameParserTests
    {
        [TestFixture]
        public class When_parsing_single_frame
        {
            private IFrame _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                const string frameText = " 1 2 ";
                var subject = new FrameParser();

                _outcome = subject.Parse(frameText);
            }

            [Test]
            public void should_return_valid_first_roll_value()
            {
                _outcome.RollOne.ShouldBe(1);
            }

            [Test]
            public void should_return_valid_second_roll_value()
            {
                _outcome.RollTwo.ShouldBe(2);
            }
        }

    }
}

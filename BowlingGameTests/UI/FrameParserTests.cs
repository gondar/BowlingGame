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

        [TestFixture]
        public class When_parsing_strike
        {
            private IFrame _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                const string frameText = " / ";
                var subject = new FrameParser();

                _outcome = subject.Parse(frameText);
            }

            [Test]
            public void should_return_strike_for_first_roll()
            {
                _outcome.RollOne.ShouldBe(10);
            }
        }

        [TestFixture]
        public class When_parsing_spare
        {
            private IFrame _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                const string frameText = " 3 / ";
                var subject = new FrameParser();

                _outcome = subject.Parse(frameText);
            }

            [Test]
            public void should_return_first_roll()
            {
                _outcome.RollOne.ShouldBe(3);
            }

            [Test]
            public void should_return_second_roll()
            {
                _outcome.RollTwo.ShouldBe(7);
            }
        }
    }
}

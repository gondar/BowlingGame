using BowlingGame.Domain;
using BowlingGame.UI;
using NUnit.Framework;
using Shouldly;

namespace BowlingGameTests.UI
{
    class FrameParserTests
    {
        [TestFixture]
        public class When_parsing_single_frame : WithFrameParser
        {
            [TestFixtureSetUp]
            public void SetUp()
            {
                Frame = Subject.Parse(" 1 2 ");
            }

            [Test]
            public void should_return_valid_first_roll_value()
            {
                Frame.RollOne.ShouldBe(1);
            }

            [Test]
            public void should_return_valid_second_roll_value()
            {
                Frame.RollTwo.ShouldBe(2);
            }
        }

        [TestFixture]
        public class When_parsing_strike : WithFrameParser
        {

            [TestFixtureSetUp]
            public void SetUp()
            {
                Frame = Subject.Parse(" / ");
            }

            [Test]
            public void should_return_strike_for_first_roll()
            {
                Frame.RollOne.ShouldBe(10);
            }
        }

        [TestFixture]
        public class When_parsing_spare : WithFrameParser
        {
            [TestFixtureSetUp]
            public void SetUp()
            {
                Frame = Subject.Parse(" 3 / ");
            }

            [Test]
            public void should_return_first_roll()
            {
                Frame.RollOne.ShouldBe(3);
            }

            [Test]
            public void should_return_second_roll()
            {
                Frame.RollTwo.ShouldBe(7);
            }
        }

        public class WithFrameParser
        {
            protected FrameParser Subject;
            protected IFrame Frame;

            [TestFixtureSetUp]
            public void SetUp()
            {
                Subject = new FrameParser();
            }
        }
    }
}

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
    class FrameTests
    {
        [TestFixture]
        public class When_computing_frame_score
        {
            private int _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var subject = new Frame
                    {
                        RollOne = 1,
                        RollTwo = 2
                    };

                _outcome = subject.GetScore(null, null);
            }

            [Test]
            public void should_return_valid_frame_score()
            {
                _outcome.ShouldBe(3);
            }
        }

        [TestFixture]
        public class When_computing_spare_score
        {
            private int _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var subject = new Frame
                    {
                        RollOne = 9,
                        RollTwo = 1
                    };
                var nextFrame = new Frame
                    {
                        RollOne = 5,
                        RollTwo = 2
                    };

                _outcome = subject.GetScore(nextFrame, null);
            }

            [Test]
            public void should_return_valid_score_including_bonus()
            {
                _outcome.ShouldBe(15);
            }
        }

        [TestFixture]
        public class When_computing_spare_in_last_frame
        {
            private int _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var subject = new Frame
                    {
                        RollOne = 9,
                        RollTwo = 1,
                        RollThree = 5
                    };

                _outcome = subject.GetScore(null, null);
            }

            [Test]
            public void should_take_into_account_third_roll()
            {
                _outcome.ShouldBe(15);
            }
        }

        [TestFixture]
        public class When_computing_strike
        {
            private int _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var subject = new Frame
                    {
                        RollOne = 10
                    };
                var next = new Frame
                    {
                        RollOne = 4,
                        RollTwo = 4
                    };

                _outcome = subject.GetScore(next, null);
            }

            [Test]
            public void should_include_next_two_rolls()
            {
                _outcome.ShouldBe(18);
            }
        }

        [TestFixture]
        public class When_computing_strike_in_last_frame
        {
            private int _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var subject = new Frame
                {
                    RollOne = 10,
                    RollTwo = 10,
                    RollThree = 10
                };

                _outcome = subject.GetScore(null, null);
            }

            [Test]
            public void should_include_next_two_rolls()
            {
                _outcome.ShouldBe(30);
            }
        }

        [TestFixture]
        public class When_computing_strike_when_next_is_strike_again
        {
            private int _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var subject = new Frame
                {
                    RollOne = 10,
                };
                var next = new Frame
                {
                    RollOne = 10
                };
                var thirdFrame = new Frame
                {
                    RollOne = 5
                };

                _outcome = subject.GetScore(next, thirdFrame);
            }

            [Test]
            public void should_include_next_two_rolls()
            {
                _outcome.ShouldBe(25);
            }
        }

        [TestFixture]
        public class When_computing_strike_when_next_is_strike_again_for_last_but_one_frame
        {
            private int _outcome;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var subject = new Frame
                {
                    RollOne = 10,
                };
                var next = new Frame
                {
                    RollOne = 10,
                    RollTwo = 5
                };

                _outcome = subject.GetScore(next, null);
            }

            [Test]
            public void should_include_next_two_rolls()
            {
                _outcome.ShouldBe(25);
            }
        }
    }
}

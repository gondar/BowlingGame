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

                _outcome = subject.GetScore(null);
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

                _outcome = subject.GetScore(nextFrame);
            }

            [Test]
            public void should_return_valid_score_including_bonus()
            {
                _outcome.ShouldBe(15);
            }
        }
    }
}

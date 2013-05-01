using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    using SystemicConsent.Core;

    using NUnit.Framework;

    public interface IOptionsProvider
    {
        Options GetOptionsForVote();
    }

    public class TestOptProv : IOptionsProvider
    {
        public Options Options = null;
        public TestOptProv(params Option[] optionTestValues)
        {
            Options = new Options();
            Options.AddRange(optionTestValues);
        }

        public Options GetOptionsForVote()
        {
            return Options;
        }
    }

    [TestFixture]
    public class VoterClientTests
    {
        private TestOptProv optionsRepo;
        private IVoterClient sut = null;

        [SetUp]
        public void Setup()
        {
           optionsRepo = new TestOptProv(OptionsTest.CHINESE);
            sut = new Client(optionsRepo);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantVoteWithoutStarting()
        {
            var curOptions = sut.GetNextOption();
            sut.VoteForCurrentOption(12);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanVoteWithStarting()
        {
            sut.StartVoting();
            var curOptions = sut.GetNextOption();
            sut.VoteForCurrentOption(12);
        }

        [Test]
        public void RestartedClientAfterCastedVoteCantVoteAgain()
        {
            //start
            sut.StartVoting();
            Assert.IsTrue(sut.IsInVoting);
            //akt option
            sut.GetNextOption();
            sut.VoteForCurrentOption(12);
            sut.Cast();

            //Exception ???
            sut.StartVoting();
            Assert.IsFalse(sut.CanVote);
            Assert.IsFalse(sut.IsInVoting);
        }


        [Test]
        public void VotingProcessWithTwoVotes()
        {
            Assert.True(sut.CanVote);
            Assert.AreEqual(optionsRepo.Options.Count, sut.AmountOfQuestion);

            sut.StartVoting();

            //option 1
            Option currentOption = sut.GetNextOption();
            Assert.AreEqual(optionsRepo.Options[0], currentOption);
            sut.VoteForCurrentOption(12);
            //option 2
            currentOption = sut.GetNextOption();
            Assert.AreEqual(optionsRepo.Options[1], currentOption);
            sut.VoteForCurrentOption(9);
            Assert.IsFalse(sut.CanVote);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    using NUnit.Framework;

    public interface IOptionsProvider
    {
        Options GetOptionsForVote();
    }



    [TestFixture]
    public class VoterClientTests
    {
        private IOptionsProvider optionsRepo;
        private IVoterClient sut = null;

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void AnzeigeDerMoeglichenOptionen()
        {
            sut.StartVoting();
            Options optionen = sut.GetOptions();
            Assert.That(optionen, Is.Not.Null);

        }
    }
}

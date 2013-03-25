using System;
using NUnit.Framework;
using System.Linq;

namespace Test
{
    [TestFixture]
    public class ModeratorTests
    {
        private Moderator _sut;

        [SetUp]
        public void SetUp ()
        {
            _sut = new Moderator ();
        }

        [Test]
        public void AModeratorClassShouldExist ()
        {
            Assert.That (_sut.Options.Count (), Is.EqualTo (0));
        }

        [Test]
        public void ShouldBeAbleToAddAnOption ()
        {
            _sut.AddOption ("Chinese");
            Assert.That (_sut.Options.Contains ("Chinese"), Is.True);
        }
        
        [Test]
        public void ShouldNotAddDuplicatedItems ()
        {
            _sut.AddOption ("Chinese");
            _sut.AddOption ("Chinese");
            Assert.That (_sut.Options.Count (), Is.EqualTo (1));
        }
    }
}


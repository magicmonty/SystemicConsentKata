using System;
using NUnit.Framework;
using System.Linq;

namespace Test
{
    [TestFixture]
    public class ModeratorTests
    {
        private Moderator _sut;
        private static readonly Option CHINESE = new Option ("Chinese");
        private static readonly Option MEXICAN = new Option ("Mexican");

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
            _sut.AddOption (new Option ("Chinese"));
            Assert.That (_sut.Options.Contains (CHINESE), Is.True);
        }
        
        [Test]
        public void ShouldNotAddDuplicatedItems ()
        {
            _sut.AddOption (new Option ("Chinese"));
            _sut.AddOption (new Option ("Chinese"));
            Assert.That (_sut.Options.Count (), Is.EqualTo (1));
        }       
        
        [Test]
        public void ShouldBeAbleToAddMultipleItems ()
        {
            _sut.AddOption (new Option ("Chinese"));
            _sut.AddOption (new Option ("Mexican"));
            Assert.That (_sut.Options.Count (), Is.EqualTo (2));
            Assert.That (_sut.Options.Contains (CHINESE), Is.True);
            Assert.That (_sut.Options.Contains (MEXICAN), Is.True);
        }       
    }
}


using System;
using System.Linq;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class OptionsTests
    {
        private Options _sut;
        private static readonly Option CHINESE = new Option ("Chinese");
        private static readonly Option MEXICAN = new Option ("Mexican");
        private static readonly Option EMPTY = new Option (string.Empty);

        [SetUp]
        public void Setup ()
        {
            _sut = new Options ();
        }

        [Test]
        public void ShouldBeEmptyIfCreated ()
        {
            Assert.That (_sut.Count (), Is.EqualTo (0));
        }

        [Test]
        public void ShouldBeAbleToAddAnOption ()
        {
            _sut.Add (new Option ("Chinese"));
            Assert.That (_sut.Contains (CHINESE), Is.True);
        }
        
        [Test]
        public void ShouldNotAddDuplicatedItems ()
        {
            _sut.Add (new Option ("Chinese"));
            _sut.Add (new Option ("Chinese"));
            Assert.That (_sut.Count (), Is.EqualTo (1));
        }       
        
        [Test]
        public void ShouldBeAbleToAddMultipleItems ()
        {
            _sut.Add (new Option ("Chinese"));
            _sut.Add (new Option ("Mexican"));
            Assert.That (_sut.Count (), Is.EqualTo (2));
            Assert.That (_sut.Contains (CHINESE), Is.True);
            Assert.That (_sut.Contains (MEXICAN), Is.True);
        }


    }
}


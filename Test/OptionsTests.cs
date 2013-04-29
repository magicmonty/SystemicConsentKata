using System.Linq;
using NUnit.Framework;
using Impl = SystemicConsent.Core;

namespace Test
{
    [TestFixture]
    public class Options
    {
        private Impl.Options _sut;
        private static readonly Impl.Option CHINESE = new Impl.Option("Chinese");
        private static readonly Impl.Option MEXICAN = new Impl.Option("Mexican");
        private static readonly Impl.Option EMPTY = new Impl.Option(string.Empty);

        [SetUp]
        public void Setup()
        {
            _sut = new Impl.Options();
        }

        [Test]
        public void ShouldBeEmptyIfCreated()
        {
            Assert.That(_sut.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ShouldBeAbleToAddAnOption()
        {
            _sut.Add(new Impl.Option("Chinese"));
            Assert.That(_sut.Contains(CHINESE), Is.True);
        }
        
        [Test]
        public void ShouldNotAddDuplicatedItems()
        {
            _sut.Add(new Impl.Option("Chinese"));
            _sut.Add(new Impl.Option("Chinese"));
            Assert.That(_sut.Count(), Is.EqualTo(1));
        }       
        
        [Test]
        public void ShouldBeAbleToAddMultipleItems()
        {
            _sut.Add(new Impl.Option("Chinese"));
            _sut.Add(new Impl.Option("Mexican"));
            Assert.That(_sut.Count(), Is.EqualTo(2));
            Assert.That(_sut.Contains(CHINESE), Is.True);
            Assert.That(_sut.Contains(MEXICAN), Is.True);
        }


    }
}


using NUnit.Framework;
using System.Linq;
using Impl = SystemicConsent.Moderator;
using Core = SystemicConsent.Core;

namespace Test
{
    [TestFixture]
    public class Moderator
    {
        private Impl.Moderator _sut;
        private static readonly Core.Option CHINESE = new Core.Option("Chinese");
        private static readonly Core.Option MEXICAN = new Core.Option("Mexican");
        private static readonly Core.Option EMPTY = new Core.Option(string.Empty);

        [SetUp]
        public void SetUp()
        {
            _sut = new Impl.Moderator(); 
        }

        [Test]
        public void ShouldHaveNoOptionsAfterCreation()
        {
            Assert.That(_sut.Options.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ShouldBeAbleToAddAnOption()
        {
            _sut.AddOption(new Core.Option("Chinese"));
            Assert.That(_sut.Options.Contains(CHINESE), Is.True);
        }
        
        [Test]
        public void ShouldNotAddDuplicatedItems()
        {
            _sut.AddOption(new Core.Option("Chinese"));
            _sut.AddOption(new Core.Option("Chinese"));
            Assert.That(_sut.Options.Count(), Is.EqualTo(1));
        }       
        
        [Test]
        public void ShouldBeAbleToAddMultipleItems()
        {
            _sut.AddOption(new Core.Option("Chinese"));
            _sut.AddOption(new Core.Option("Mexican"));
            Assert.That(_sut.Options.Count(), Is.EqualTo(2));
            Assert.That(_sut.Options.Contains(CHINESE), Is.True);
            Assert.That(_sut.Options.Contains(MEXICAN), Is.True);
        }       

        [Test]
        public void ShouldCloseInputOfOptionsIfEmptyOptionIsAdded()
        {
            _sut.AddOption(EMPTY);

            Assert.That(_sut.IsClosed, Is.True);
        }

        
        [Test]
        public void ShouldNotAllowNewOptionsOnClosedInput()
        {
            _sut.AddOption(EMPTY);
            _sut.AddOption(CHINESE);
            
            Assert.That(_sut.Options.Count(), Is.EqualTo(0));
        }


    }
}


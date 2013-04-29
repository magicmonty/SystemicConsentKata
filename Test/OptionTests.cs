using NUnit.Framework;
using Impl = SystemicConsent.Core;

namespace Test
{
    [TestFixture()]
    public class Option
    {
        [Test]
        public void ShouldHaveTheCorrectName()
        {
            var option = new Impl.Option("Hallo Welt");
            Assert.That(option.Name, Is.EqualTo("Hallo Welt"));
        }

        [Test]
        public void ShouldBeEqualIfNameIsEqual()
        {
            Assert.That(new Impl.Option("Test").Equals(new Impl.Option("Test")), Is.True);
        }

        [Test]
        public void ShouldBeSameIfNameIsEqual()
        {
            Assert.That(new Impl.Option("Test") == new Impl.Option("Test"), Is.True);
        }
    }
}


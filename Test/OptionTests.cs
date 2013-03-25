using System;
using NUnit.Framework;

namespace Test
{
    [TestFixture()]
    public class OptionTests
    {
        [Test]
        public void ShouldHaveTheCorrectName ()
        {
            var option = new Option ("Hallo Welt");
            Assert.That (option.Name, Is.EqualTo ("Hallo Welt"));
        }

        [Test]
        public void ShouldBeEqualIfNameIsEqual ()
        {
            Assert.That (new Option ("Test").Equals (new Option ("Test")), Is.True);
        }

        [Test]
        public void ShouldBeSameIfNameIsEqual ()
        {
            Assert.That (new Option ("Test") == new Option ("Test"), Is.True);
        }
    }
}


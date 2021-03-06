using NUnit.Framework;
using System.Linq;
using Impl = SystemicConsent.Moderator;
using Core = SystemicConsent.Core;

namespace Test
{
    class MockProvider : Core.IOptionsProvider
    {
        public bool StoreIsRun;
        private Core.Options _options;

        public Core.Options GetOptions()
        {
            return _options;
        }

        public void StoreOptions(Core.Options options)
        {
            StoreIsRun = true;
            _options = options;
        }
    }

    [TestFixture]
    public class Moderator
    {
        private Impl.Moderator _sut;
        private MockProvider _provider;

        private static readonly Core.Option CHINESE = new Core.Option("Chinese");
        private static readonly Core.Option MEXICAN = new Core.Option("Mexican");
        private static readonly Core.Option EMPTY = new Core.Option(string.Empty);

        [SetUp]
        public void SetUp()
        {
            _provider = new MockProvider();
            _sut = new Impl.Moderator(_provider); 
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

        [Test]
        public void ShouldPublishToOptionsProviderOnPublishIfClosed()
        {
            _sut.AddOption(CHINESE);
            _sut.AddOption(EMPTY);
            _sut.Publish();

            Assert.That(_provider.StoreIsRun, Is.True);
        }

        [Test]
        public void ShouldNotPublishToOptionsProviderOnPublishIfNotClosed()
        {
            _sut.AddOption(CHINESE);
            _sut.Publish();
            
            Assert.That(_provider.StoreIsRun, Is.False);
        }
        
        [Test]
        public void ShouldPublishTheCorrectOptionsToOptionsProviderOnPublish()
        {
            _sut.AddOption(CHINESE);
            _sut.AddOption(EMPTY);
            _sut.Publish();
            
            Assert.That(_provider.GetOptions(), Is.EqualTo(_sut.Options));
        }

        [Test]
        public void ShouldReturnTheOptionWithTheLeastValueOnGetRecommendation()
        {
            var options = new Core.Options();
            var option1 = new Core.Option("Chinese");
            var option2 = new Core.Option("Italian");
            option1.Vote(6);
            option2.Vote(4);

            options.Add(option1);
            options.Add(option2);

            _provider.StoreOptions(options);

            var recommendation = _sut.GetRecommendation();
            Assert.That(recommendation.Count(), Is.EqualTo(1));
            Assert.That(recommendation.First(), Is.EqualTo(option2));
            Assert.That(recommendation.First().Value, Is.EqualTo(4));
        }

        [Test]
        public void ShouldReturnEmptyListOnGetRecommendationIfOptionsAreEmpty()
        {
            Assert.That(_sut.GetRecommendation(), Is.EqualTo(Enumerable.Empty<Core.Option>()));
        }

        private Core.Option CreateOption(string name, int value)
        {
            var result = new Core.Option(name);
            result.Vote(value);

            return result;
        }

        [Test]
        public void ShouldReturnMultipleOptionsIfResistanceIsSame()
        {
            var options = new Core.Options();
            var option1 = CreateOption("Chinese", 5);
            var option2 = CreateOption("Italian", 6);
            var option3 = CreateOption("Mexican", 5);

            options.Add(option1);
            options.Add(option2);
            options.Add(option3);

            _provider.StoreOptions(options);

            Assert.That(_sut.GetRecommendation().Count(), Is.EqualTo(2));
        }
    }
}


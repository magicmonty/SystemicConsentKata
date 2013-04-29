using System.Collections.Generic;
using SystemicConsent.Core;
using System.Linq;

namespace SystemicConsent.Moderator
{
    public class Moderator
    {
        private readonly IOptionsProvider _optionsProvider;

        public static readonly Option EMPTY = new Option(string.Empty);

        public IEnumerable<Option> Options { get { return _options; } }
        private IEnumerable<Option> _options = new Options();

        public Moderator(IOptionsProvider optionsProvider)
        {
            _optionsProvider = optionsProvider;
        }

        public bool IsClosed {
            get { return _isClosed; }
        }
        private bool _isClosed;

        public void AddOption(Option option)
        {
            CloseIfEmptyOption(option);
            if (!IsClosed) {
                var asList = _options as Options;
                asList.Add(option);
                _options = asList;
            }
        }

        private void CloseIfEmptyOption(Option option)
        {
            if (option == EMPTY)
                _isClosed = true;
        }

        public void Publish()
        {
            if (IsClosed) {
                _optionsProvider.StoreOptions(_options as Options);
            }
        }

        public Option GetRecommendation()
        {
            var options = _optionsProvider.GetOptions() ?? new Options();
            Option result = options.OrderBy(option => option.Value)
                                   .FirstOrDefault();

            if ((object)result == (object)null) {
                result = new Option(string.Empty);
            }

            return result;
        }
    }

}


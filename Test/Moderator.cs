using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Moderator
    {
        public static readonly Option EMPTY = new Option (string.Empty);

        public IEnumerable<Option> Options { get { return _options; } }
        private IEnumerable<Option> _options = new Options ();

        public bool IsClosed {
            get { return _isClosed; }
        }
        private bool _isClosed;

        public void AddOption (Option option)
        {
            CloseIfEmptyOption (option);
            if (!IsClosed) {
                var asList = _options as Options;
                asList.Add (option);
                _options = asList;
            }
        }

        void CloseIfEmptyOption (Option option)
        {
            if (option == EMPTY)
                _isClosed = true;
        }
    }

}


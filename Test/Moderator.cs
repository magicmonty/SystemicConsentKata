using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Moderator
    {
        public IEnumerable<Option> Options { get { return _options; } }
        private IEnumerable<Option> _options = new List<Option> ();

        public void AddOption (Option option)
        {
            var asList = _options.ToList ();
            asList.Add (option);
            _options = asList.Distinct ();
        }
    }

}


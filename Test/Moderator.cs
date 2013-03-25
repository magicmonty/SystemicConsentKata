using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Moderator
    {
        public IEnumerable<string> Options { get { return _options; } }
        private IEnumerable<string> _options = new List<string> ();

        public void AddOption (string option)
        {
            var asList = _options.ToList ();
            asList.Add (option);
            _options = asList.Distinct ();
        }
    }

}


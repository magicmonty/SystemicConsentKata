using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    public class Options : List<Option>
    {
        public new void Add (Option value)
        {
            if (!Contains (value)) {
                base.Add (value);
            }
        }
    }

}


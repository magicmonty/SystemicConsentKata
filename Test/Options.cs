using System.Collections.Generic;

namespace SystemicConsent.Core
{
    public class Options : List<Option>
    {
        public new void Add(Option value)
        {
            if (!Contains(value)) {
                base.Add(value);
            }
        }
    }

}


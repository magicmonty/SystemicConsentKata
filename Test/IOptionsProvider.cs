using System;

namespace SystemicConsent.Core
{
    public interface IOptionsProvider
    {
        Options GetOptions();
        void StoreOptions(Options options);
    }
}


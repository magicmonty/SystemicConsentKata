using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    interface IVoterClient
    {
        void StartVoting();
        bool CanVote { get; }
        int AmountOfQuestion { get; }
        bool IsInVoting { get;  }
        SystemicConsent.Core.Option GetNextOption();
        void VoteForCurrentOption(int p);
        void Cast();
        void Exit();
    }
}

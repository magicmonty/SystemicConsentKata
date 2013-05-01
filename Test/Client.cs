using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    using SystemicConsent.Core;

    class Client : IVoterClient
    {
        private IOptionsProvider OptionsProvider;

        public Client(IOptionsProvider optionProvider)
        {
            this.OptionsProvider = optionProvider;
        }
        Stack<Option> options = new Stack<Option>();  
        public void StartVoting()
        {
            options = new Stack<Option>(OptionsProvider.GetOptionsForVote());
            IsInVoting = true;
        }

        public bool CanVote { get; set; }

        public int AmountOfQuestion
        {
            get { return options.Count; }
        }

        public bool IsInVoting { get; set; }

        public SystemicConsent.Core.Option GetNextOption()
        {
            return options.Pop();
        }

        public void VoteForCurrentOption(int p)
        {
            
        }

        public void Cast()
        {
           
        }

        public void Exit()
        {
            IsInVoting = false;
            CanVote = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Breakthrough
{
    class GeniusCard : Card
    {
        public string CardType { get; set; } = "Gen";
        public GeniusCard() : base()
        { }

        public override string GetCardDetails() => CardType;

        public override void Process(
            CardCollection deck,
            CardCollection discard,
            CardCollection hand,
            CardCollection sequence,
            Lock currentLock,
            string choice,
            int cardChoice /*this does nothing and shouldnt be here*/)
        {
            if (Int32.TryParse(choice, out int challengeToSolve))
            {

                return;
            }
        }
    }
}

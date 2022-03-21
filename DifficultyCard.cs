//Skeleton Program code for the AQA A Level Paper 1 Summer 2022 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Breakthrough
{
    class DifficultyCard : Card
    {
        protected string CardType;

        public DifficultyCard()
            : base()
        {
            CardType = "Dif";
        }

        public DifficultyCard(int cardNo)
        {
            CardType = "Dif";
            CardNumber = cardNo;
        }

        public override string GetCardDetails()
        {
            return CardType;
        }

        public override void Process(
            CardCollection deck,
            CardCollection discard,
            CardCollection hand,
            CardCollection sequence,
            Lock currentLock,
            string choice,
            int cardChoice)
        {
            int ChoiceAsInteger;
            if (int.TryParse(choice, out ChoiceAsInteger))
            {
                if (ChoiceAsInteger >= 1 && ChoiceAsInteger <= 5)
                {
                    if (ChoiceAsInteger >= cardChoice)
                    {
                        ChoiceAsInteger -= 1;
                    }
                    if (ChoiceAsInteger > 0)
                    {
                        ChoiceAsInteger -= 1;
                    }
                    if (hand.GetCardDetailsAt(ChoiceAsInteger)[0] == 'K')
                    {
                        Card CardToMove = hand.RemoveCard(hand.GetCardNumberAt(ChoiceAsInteger));
                        discard.AddCard(CardToMove);
                        return;
                    }
                }
            }
            int Count = 0;
            while (Count < 5 && deck.GetNumberOfCards() > 0)
            {
                Card CardToMove = deck.RemoveCard(deck.GetCardNumberAt(0));
                discard.AddCard(CardToMove);
                Count += 1;
            }
        }
    }
}
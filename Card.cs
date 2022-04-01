//Skeleton Program code for the AQA A Level Paper 1 Summer 2022 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Breakthrough
{
    abstract class Card
    {
        protected int CardNumber, Score;
        protected static int NextCardNumber = 1;

        public Card()
        {
            CardNumber = NextCardNumber;
            NextCardNumber += 1;
            Score = 0;
        }

        public virtual int GetScore()
        {
            return Score;
        }

        public abstract void Process(CardCollection deck, CardCollection discard,
            CardCollection hand, CardCollection sequence, Lock currentLock,
            string choice, int cardChoice);

        public virtual int GetCardNumber()
        {
            return CardNumber;
        }

        public string GetDescription()
        {
            return GetCardDetails() + " " + CardNumber.ToString();
        }

        public virtual string GetCardDetails()
        {
            return string.Empty;
        }
    }
}
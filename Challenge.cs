//Skeleton Program code for the AQA A Level Paper 1 Summer 2022 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

using System.Collections.Generic;

namespace Breakthrough
{
    public class Challenge
    {
        protected List<string> Condition;
        public ChallengeStatus Status { get; set; }
        public bool IsSolved => Status == ChallengeStatus.Solved;

        public Challenge()
        {
            Status = ChallengeStatus.Unsolved;
        }

        public List<string> GetCondition()
        {
            return Condition;
        }

        public void SetCondition(List<string> newCondition)
        {
            Condition = newCondition;
        }

        public override string ToString()
        {
            return string.Join(',', Condition);
        }

        public static bool IsPartiallySolved(string conditions, string sequence)
        {
            var partiallySolved = false;
            var i = 2;
            while (!partiallySolved && i < conditions.Length)
            {
                // compare start of condition and end of sequence
                partiallySolved = sequence.EndsWith(conditions.Substring(0, i));
                i += 4;
            }
            return partiallySolved;
        }
    }
}
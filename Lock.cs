//Skeleton Program code for the AQA A Level Paper 1 Summer 2022 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

using System;
using System.Collections.Generic;
using System.Linq;

namespace Breakthrough
{
    class Lock
    {
        protected List<Challenge> Challenges = new List<Challenge>();
        public bool CanPeek { get; set; } = true;

        public virtual void AddChallenge(List<string> condition)
        {
            Challenge C = new Challenge();
            C.SetCondition(condition);
            Challenges.Add(C);
        }

        private string ConvertConditionToString(List<string> c)
        {
            string ConditionAsString = "";
            for (int Pos = 0; Pos <= c.Count - 2; Pos++)
            {
                ConditionAsString += c[Pos] + ", ";
            }
            ConditionAsString += c[c.Count - 1];
            return ConditionAsString;
        }

        public virtual string GetLockDetails()
        {
            string LockDetails = Environment.NewLine + "CURRENT LOCK" + Environment.NewLine + "------------" + Environment.NewLine;
            foreach (var challenge in Challenges)
            {
                switch (challenge.Status)
                {
                    case ChallengeStatus.Solved:
                        LockDetails += "Challenge met: ";
                        break;
                    case ChallengeStatus.PartiallySolved:
                        LockDetails += "Partially met: ";
                        break;
                    default:
                        LockDetails += "Not met:       ";
                        break;
                }

                LockDetails += ConvertConditionToString(challenge.GetCondition()) + Environment.NewLine;
            }
            LockDetails += Environment.NewLine;
            return LockDetails;
        }

        public virtual bool GetLockSolved()
        {
            foreach (var C in Challenges)
            {
                if (!C.IsSolved)
                {
                    return false;
                }
            }
            return true;
        }

        public virtual bool CheckIfConditionMet(string sequence)
        {
            foreach (var challenge in Challenges)
            {
                var conditionString = ConvertConditionToString(challenge.GetCondition());
                if (!challenge.IsSolved && sequence == conditionString)
                {
                    challenge.Status = ChallengeStatus.Solved;
                    return true;
                }
                else if (!challenge.IsSolved && 
                    Challenge.IsPartiallySolved(conditionString, sequence))
                {
                    challenge.Status = ChallengeStatus.PartiallySolved;
                }
            }
            return false;
        }

        public virtual void SetChallengeMet(int pos, bool value)
        {
            Challenges[pos].Status = value ?
                ChallengeStatus.Solved : ChallengeStatus.Unsolved;
        }

        public virtual bool GetChallengeMet(int pos)
        {
            return Challenges[pos].IsSolved;
        }

        public virtual int GetNumberOfChallenges()
        {
            return Challenges.Count;
        }

        public string GetChallengesAsString()
        {
            return string.Join(";", Challenges.Select(c => c.ToString()));
        }
        
        public string GetChallengeStatusAsString()
        {
            return string.Join(";", Challenges.Select(c => c.IsSolved ? "Y" : "N"));
        }
    }
}
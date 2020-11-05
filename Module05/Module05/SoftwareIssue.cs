using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module05
{
    class SoftwareIssue : Issue
    {



        public SoftwareIssue(string description, IssueStatus status, string appName) : base(description,status)
        {
            this.ApplicationName = appName;
        }


        public string OS { get; set; }

        public string ApplicationName { get; set; }

        public string ErrorMessage { get; set; }


        //Override - to change the bahavior of an existing member
        //1) Give permission in the base class
        //2) Override the member

        public override string Summarize()
        {
            var initialSummary= base.Summarize();
            return initialSummary + $"AppName: {ApplicationName}\n" +
                            $"OS: {OS}\n" +
                            $"Error: {ErrorMessage}";


        }
    }


    public class AccountLockedException : Exception
    {
        public AccountLockedException()
        {
        }

        public AccountLockedException(string message) : base(message)
        {
        }

        public AccountLockedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }




    class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
    }

    class Game
    {


        void Play()
        {

            Hand hand1 = Deal();
            Hand hand2 = Deal();
            Hand hand3 = Deal();
            Hand hand4 = Deal();

  
        }

        private Hand Deal()
        {
            throw new NotImplementedException();
        }
    }

    class Hand : List<Card>
    {
        public bool HasPair { get; set; }
        public bool IsFlush { get; set; }

    }


}

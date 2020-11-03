using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient; //Optional

namespace Module01.SimpleApp
{
    class Program
    {
        static void Main(string[] args)
        {



            Random rnd = new Random();


            int answer = rnd.Next(1,101);
            int guess;
            const int MAX_GUESSSES = 5;
            int[] allGuesses = new int[MAX_GUESSSES];
            int currentGuessCount = 0;
            string direction = "Pick a number between 1 and 100";

            do
            {

                //snippet: cw<tab><tab>
                Console.WriteLine(direction);
                var userGuess = Console.ReadLine();
                guess = int.Parse(userGuess);

                allGuesses[currentGuessCount] = guess;
                currentGuessCount++;

                if (answer == guess)
                {
                    
                    Console.WriteLine("You are amazing!!!!");
                }
                else 
                
                if (answer > guess)
                {
                    Console.WriteLine("Too low");
                }
                else if (answer < guess)
                {
                    Console.WriteLine("Too High");

                }
                else
                {

                    Console.WriteLine("There shouldn't be a way to get here");
                } 
            } while (answer != guess && currentGuessCount < MAX_GUESSSES);

            
            if(answer == guess)
            {
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine("You Lose!");
            }


            Console.WriteLine("You guesses");
            foreach(var round in allGuesses)
            {
                if(round != 0)
                {
                    Console.WriteLine(round);
                }


            }



        }

        double SalesTaxRate(string stateAbv)
        {

            double rate = 0;
            switch (stateAbv)
            {
                case "OK":
                    rate = .08;
                    break;
                case "MI":
                case "DC":
                case "IL":
                    rate = .06;
                    break;
                case "OH":
                    rate = 0.575;
                    break;
                case "WI":
                    rate = .05;
                    break;
            }


            return rate;

        }


        //string DayOfWeekMessage(DayOfWeek day)
        //{
        //    //switch<tab><tab>day<enter><enter>
        //    switch (day)
        //    {
        //        case DayOfWeek.Sunday:
        //            break;
        //        case DayOfWeek.Monday:
        //            break;
        //        case DayOfWeek.Tuesday:
        //            break;
        //        case DayOfWeek.Wednesday:
        //            break;
        //        case DayOfWeek.Thursday:
        //            break;
        //        case DayOfWeek.Friday:
        //            break;
        //        case DayOfWeek.Saturday:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        void CountDown(int start)
        {

            for(int current = start; current > 0; current--)
            {
                Console.WriteLine($"Value: {current}!!!");
            }

            //for<tab><tab>



        }

    }
}

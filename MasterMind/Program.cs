using MasterMind.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MasterMind.");
            Console.WriteLine("Try to guess the four digit number. Each number can be a value between 1 and 6. You have 10 guesses. Good luck!");
            Console.WriteLine("===========================================================");
            

            var codeMaker = new CodeMaker();
            var codeBreaker = new CodeBreaker();

            string codeAnswer = codeMaker.GenerateRandomAnswer();

            while (codeBreaker.AttemptsRemaining > 0)
            {
                string codeGuess = Console.ReadLine();
                string response = codeBreaker.SolveCode(codeGuess, codeAnswer);
                Console.WriteLine(response);
            }
            Console.WriteLine("Thanks for playing! Press any key to exit.");
            Console.ReadKey();
        }
    }
}

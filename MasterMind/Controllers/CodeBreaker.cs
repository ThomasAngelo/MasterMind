using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Controllers
{
    public class CodeBreaker
    {
        public int AttemptsRemaining { get; set; }

        public CodeBreaker()
        {
            AttemptsRemaining = 10;
        }

        public string SolveCode(string codeGuess, string codeAnswer)
        {
            
            if (!ValidateCodeGuess(codeGuess))
            {
                return "Please enter a 4 digit number with each digit betweemn 1 and 6.";
            }

            string response = CreateResponse(codeGuess, codeAnswer);

            return response;
        }

        private string CreateResponse(string codeGuess, string codeAnswer)
        {
            string response = "";
            if (codeGuess == codeAnswer)
            {
                this.AttemptsRemaining = 0;
                return "Congratulations! You win. You are a true MasterMind!";
            }

            response = DeterminePlusMinusResponse(codeGuess, codeAnswer);            

            this.AttemptsRemaining--;
            response += String.Format(System.Environment.NewLine + "You have {0} attempts remaining.",this.AttemptsRemaining);
            if(AttemptsRemaining == 0)
            {
                response += String.Format(System.Environment.NewLine + "Sorry! You lose! The correct answer was {0}",codeAnswer);
            }
            return response;
        }

        private string DeterminePlusMinusResponse(string codeGuess, string codeAnswer)
        {
            string response = "";
            var sb = new StringBuilder(codeGuess);
            for (int i = 0; i <= 3; i++)
            {
                if (codeGuess[i] == codeAnswer[i])
                {
                    response += "+";

                    //this ensures that we won't later display a minus sign for a number that is already matched successfully
                    sb[i] = '*';
                    codeGuess = sb.ToString();
                }
            }

            for (int i = 0; i < codeGuess.Length; i++)
            {
                for (int j = 0; j < codeAnswer.Length; j++)
                {
                    if (i != j && codeGuess[i] == codeAnswer[j])
                    {
                        response += "-";
                        break;
                    }
                }
            }

            return response;
        }

        private bool ValidateCodeGuess(string codeGuess)
        {
            bool isInteger = int.TryParse(codeGuess, out int numericCodeGuess);
            if (!isInteger)
            {
                return false;
            }

            if(codeGuess.Length != 4)
            {
                return false;
            }

            foreach (char num in codeGuess)
            {
                if (Char.GetNumericValue(num) < 1 || Char.GetNumericValue(num) > 6)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Controllers
{
    public class CodeMaker
    {
        public CodeMaker()
        {

        }

        public string GenerateRandomAnswer()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int[] randomCode = new int[3];
            string codeAnswer = "";
            for(int i=0; i<=3; i++)
            {
                codeAnswer += rand.Next(1, 6);
            }

            return codeAnswer;
        }
    }
}

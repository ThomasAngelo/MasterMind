using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterMind.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.Controllers.Tests
{
    [TestClass()]
    public class CodeBreakerTests
    {

        [TestMethod()]
        public void SolveCodeTooManyCharacters()
        {
            string codeGuess = "123456";
            string codeAnswer = "1234";
            var codeBreaker = new CodeBreaker();

            var response = codeBreaker.SolveCode(codeGuess, codeAnswer);

            Assert.AreEqual(response, "Please enter a 4 digit number with each digit betweemn 1 and 6.");
        }

        [TestMethod()]
        public void SolveCodeNonNumericCharacters()
        {
            string codeGuess = "12hd";
            string codeAnswer = "1234";
            var codeBreaker = new CodeBreaker();

            var response = codeBreaker.SolveCode(codeGuess, codeAnswer);

            Assert.AreEqual(response, "Please enter a 4 digit number with each digit betweemn 1 and 6.");
        }

        [TestMethod()]
        public void SolveCodeTooFewCharacters()
        {
            string codeGuess = "12";
            string codeAnswer = "1234";
            var codeBreaker = new CodeBreaker();

            var response = codeBreaker.SolveCode(codeGuess, codeAnswer);

            Assert.AreEqual(response, "Please enter a 4 digit number with each digit betweemn 1 and 6.");
        }

        [TestMethod()]
        public void SolveCodeCharacterValuesTooHighOrLow()
        {
            string codeGuess = "0173";
            string codeAnswer = "1234";
            var codeBreaker = new CodeBreaker();

            var response = codeBreaker.SolveCode(codeGuess, codeAnswer);

            Assert.AreEqual(response, "Please enter a 4 digit number with each digit betweemn 1 and 6.");
        }

        [TestMethod()]
        public void SolveCodeWorking()
        {
            string codeGuess = "1253";
            string codeAnswer = "1234";
            var codeBreaker = new CodeBreaker();

            var response = codeBreaker.SolveCode(codeGuess, codeAnswer);

            Assert.AreEqual(response, "++-" + System.Environment.NewLine + "You have 9 attempts remaining.");
        }

        [TestMethod()]
        public void SolveCodeYouWin()
        {
            string codeGuess = "1234";
            string codeAnswer = "1234";
            var codeBreaker = new CodeBreaker();

            var response = codeBreaker.SolveCode(codeGuess, codeAnswer);

            Assert.AreEqual(response, "Congratulations! You win. You are a true MasterMind!");
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeCalculator.Tests
{
    [TestClass()]
    public class CalculatorManagerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            CalculatorManager cm = new CalculatorManager();

            // null check
            try
            {
                cm.Add(null);
            }
            catch(ArgumentException)
            {
                // Pass... should throw an ArgumentException
            }


            // Requirement 1:  Support two numbers 

            Assert.AreEqual(cm.Add(""), 0);
            Assert.AreEqual(cm.Add("20"), 20);
            Assert.AreEqual(cm.Add("1,5000"), 5001); // test two numbers
            Assert.AreEqual(cm.Add("5,tytyt"), 5);
            Assert.AreEqual(cm.Add("5.2,5"), 5);  // test that decimals don't break anything
                                                  // Assert.AreEqual(cm.Add("5,2,3"), 7); // three or more values not allowed  (REMOVED for Requirement 2)    

            // Requirement 2:  Support unlimited numbers

            Assert.AreEqual(cm.Add("1,2,3,4,5,6,7,8,9,10,11,12"), 78);
        }
    }
}
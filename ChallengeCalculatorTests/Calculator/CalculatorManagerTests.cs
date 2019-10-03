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
                Assert.Fail("FAIL:  NULL value not handled properly.");
            }
            catch (ArgumentException)
            {
                // Pass... should throw an ArgumentException
            }
            catch
            {
                Assert.Fail("FAIL:  NULL value not handled properly.");
            }

            // Requirement 1:  Support two numbers 

            Assert.AreEqual(cm.Add(""), 0);
            Assert.AreEqual(cm.Add("20"), 20);
            Assert.AreEqual(cm.Add("1,500"), 501); // test two numbers
            Assert.AreEqual(cm.Add("5,tytyt"), 5);
            Assert.AreEqual(cm.Add("5.2,5"), 5);  // test that decimals don't break anything
                                                  // Assert.AreEqual(cm.Add("5,2,3"), 7); // three or more values not allowed  (REMOVED for Requirement 2)    

            // Requirement 2:  Support unlimited numbers

            Assert.AreEqual(cm.Add("1,2,3,4,5,6,7,8,9,10,11,12"), 78);

            // Requirement 3:  Support a newline character as an alternative delimiter

            Assert.AreEqual(cm.Add("1\n2,3"), 6);
            Assert.AreEqual(cm.Add("1\n2,3\n5"), 11);

            // Requirement 4:  Deny negative numbers
            try
            {
                cm.Add("-5,-2,-3");
                Assert.Fail("FAIL:  Negative values not handled properly.");
            }
            catch(ArgumentException)
            {
                // Pass... should throw an ArgumentException
            }
            catch
            {
                Assert.Fail("FAIL:  Negative values not handled properly.");
            }

            // Requirement 5:  Ignore any number greater than 1000

            Assert.AreEqual(cm.Add("2,1001,6"), 8);
        }
    }
}
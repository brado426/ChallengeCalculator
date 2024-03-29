﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(cm.Add(""), 0);        // test for empty string
            Assert.AreEqual(cm.Add("20"), 20);
            Assert.AreEqual(cm.Add("1,500"), 501); // test two numbers
            Assert.AreEqual(cm.Add("5,tytyt"), 5);
            Assert.AreEqual(cm.Add("5.2,5"), 5);   // test that decimals don't break anything
                                                   // Assert.AreEqual(cm.Add("5,2,3"), 7); // three or more values not allowed  (REMOVED for Requirement 2)    

            // Requirement 2:  Support unlimited numbers

            Assert.AreEqual(cm.Add("1,2,3,4,5,6,7,8,9,10,11,12"), 78);

            // Requirement 3:  Support a newline character as an alternative delimiter

            Assert.AreEqual(cm.Add("1\n2,3"), 6);
            Assert.AreEqual(cm.Add("1\n2,3\n5"), 11);

            CalculatorManager cmNeg = new CalculatorManager(false);  // For Requirement 3b

            // Requirement 4:  Deny negative numbers
            try
            {
                // Requirement 3b: Toggle whether to deny negative numbers
                Assert.AreEqual(cmNeg.Add("-5,-2,-3"), -10);
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

            // Requirement 6:  Support 1 custom single character length delimiter

            Assert.AreEqual(cm.Add("//;\n2;5"), 7);

            // Requirement 7:  Support 1 custom delimiter of any length

            Assert.AreEqual(cm.Add("//[***]\n11***22***33"), 66);

            // Requirement 8:  Support 1 custom delimiter of any length

            Assert.AreEqual(cm.Add("//[*][!!][r9r]\n11r9r22*33!!44"), 110);

            // TODO:  Add more test cases for each requirement
        }
    }
}
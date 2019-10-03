using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChallengeCalculator 
{
    public class CalculatorManager : IDisposable
    {
        public CalculatorManager()
        {
        }

        public int Add(string input)
        {
            if (input == null)
                throw new ArgumentException("This method does not allow NULL values.");

            int returnInteger = 0;

            string[] values = input.Split(new char[] { ',', '\n' });

            List<int> validValues = new List<int>();

            foreach(string value in values)
            {
                bool isNumeric = int.TryParse(value, out int numValue);

                if (isNumeric)  
                    numValue = Convert.ToInt32(value);
                else 
                    numValue = 0;

                validValues.Add(numValue);
                returnInteger += numValue;
            }

            // Requirement 4 - Deny negative numbers
            List<int> negativeNumbers = validValues.Where(v => v < 0).ToList();     
            if (negativeNumbers.Count > 0)
            {
                 throw new ArgumentException($"Negative numbers are not supported. {string.Join(", ", negativeNumbers)}");
            }

            return returnInteger;
        }

        public void Dispose()
        {
            // nothing to dispose yet
        }
    }
}

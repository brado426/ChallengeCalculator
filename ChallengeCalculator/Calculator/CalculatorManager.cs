using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

            string[] values = input.Split(',');

            foreach(string value in values)
            {
                bool isNumeric = int.TryParse(value, out int numValue);

                if (isNumeric)  
                    numValue = Convert.ToInt32(value);
                else 
                    numValue = 0;
                
                returnInteger += numValue;
            }

            return returnInteger;
        }

        public void Dispose()
        {
            // nothing to dispose yet
        }
    }
}

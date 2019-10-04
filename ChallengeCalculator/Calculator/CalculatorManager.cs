using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChallengeCalculator
{
    public class CalculatorManager : IDisposable
    {
        private int _maximumValue;
        private List<string> defaultDelimiters = new List<string> { ",", "\n" };
        private bool _denyNegatives;
        private string _alternateDelimiter = null;

        public CalculatorManager(bool denyNegative = true, int maximumValue = 1000, string alternateDelimiter = null)
        {
            _denyNegatives = denyNegative;
            _maximumValue = maximumValue;
            _alternateDelimiter = alternateDelimiter;
        }

        public int Add(string input)
        {
            if (input == null)
                throw new ArgumentException("This method does not allow NULL values.");

            int returnInteger = 0;

            string[] values = ProcessCalculatorString(input);

            List<int> validValues = new List<int>();

            foreach (string value in values)
            {
                bool isNumeric = int.TryParse(value, out int numValue);

                if (isNumeric && numValue <= _maximumValue)
                    numValue = Convert.ToInt32(value);
                else
                    numValue = 0;

                validValues.Add(numValue);
                returnInteger += numValue;
            }

            // Requirement 4 - Deny negative numbers
            List<int> negativeNumbers = validValues.Where(v => v < 0).ToList();
            if (_denyNegatives && negativeNumbers.Count > 0)
            {
                throw new ArgumentException($"Negative numbers are not supported. {string.Join(", ", negativeNumbers)}");
            }

            return returnInteger;
        }

        private string[] ProcessCalculatorString(string input)
        {
            List<string> delimiters = defaultDelimiters;

            if (_alternateDelimiter != null)
                delimiters.Add(_alternateDelimiter);

            if (input.StartsWith("//"))
            {
                MatchCollection custDeliminters = Regex.Matches(input, @"\[(.*?)\]");

                if (custDeliminters.Count > 0)
                {
                    // to support requirements 7 and 8
                    foreach (Match delimiter in custDeliminters)
                        delimiters.Add(delimiter.Value.Replace("[", String.Empty).Replace("]", String.Empty));
                }
                else
                {
                    // to support requirement 6
                    delimiters.Add(input[2].ToString());
                }

                int endOfDelimiterIndex = input.IndexOf('\n');

                // we need to remove the delimiter specification in the input string.  As per the specs, the delimiter for this must be \n
                if (endOfDelimiterIndex >= 0)
                    input = input.Substring(endOfDelimiterIndex);
            }

            return input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

    public void Dispose()
    {
        // nothing to dispose yet
    }
}
}

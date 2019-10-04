using System;
using System.Configuration;

namespace ChallengeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter the formula to test: ");
                string strInput = Console.ReadLine();

                try
                {
                    int maximumValue = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumValue"]);
                    bool denyNegativeNumbers = Convert.ToBoolean(ConfigurationManager.AppSettings["DenyNegativeNumbers"]);

                    using (CalculatorManager calc = new CalculatorManager(denyNegativeNumbers, maximumValue))
                    {
                        int result = calc.Add(strInput);
                        Console.WriteLine($"The result is {result}");
                    }
                }
                catch (Exception ex)
                {
                    // log exception to exception repository
                    // Logger.LogError(ex);
                }
            }
        }
    }
}

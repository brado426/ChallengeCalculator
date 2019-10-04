using System;

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
                    using (CalculatorManager calc = new CalculatorManager())
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

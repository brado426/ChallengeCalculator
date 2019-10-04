using System;
using System.Configuration;

namespace ChallengeCalculator
{
    class Program
    {
        private static int maximumValue = 1000;
        private static bool denyNegativeNumbers = true;
        private static string alternateDelimiter = null;

        static void Main(string[] args)
        {
            InitializeConfiguration();

            while (true)
            {
                Console.Write("Please enter the formula to test: ");
                string strInput = Console.ReadLine();

                try
                {
                    using (CalculatorManager calc = new CalculatorManager(denyNegativeNumbers, maximumValue, alternateDelimiter))
                    {
                        int result = calc.Add(strInput);
                        Console.WriteLine($"The result is {result}");
                    }
                }
                catch (Exception ex)
                {
                    // TODO:  Log any exceptions to appropriate exception log repository
                    // Logger.LogError(ex);
                }
            }
        }

        private static void InitializeConfiguration()
        {
            string[] cmdLine = Environment.GetCommandLineArgs();

            try
            {
                foreach (string cmd in cmdLine)
                {
                    int cmdIndex = Array.IndexOf(cmdLine, cmd);

                    switch (cmd)
                    {
                        case "-MaximumValue":
                            maximumValue = Convert.ToInt32(cmdLine[cmdIndex + 1]);
                            break;

                        case "-DenyNegativeNumbers":
                            denyNegativeNumbers = Convert.ToBoolean(cmdLine[cmdIndex + 1]);
                            break;

                        case "-AlternateDelimiter":
                            alternateDelimiter = cmdLine[cmdIndex + 1];
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unable to parse command-line: {ex.Message}");
            }
        }
    }
}

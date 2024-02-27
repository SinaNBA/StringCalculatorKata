﻿namespace StringCalculatorKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The sum is(with ',') for step1: {Add("1,2,3")}");
            Console.WriteLine($"The sum is(with ',')for step3: {Add("1,\n2,3")}");
        }
        private static int Add(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString)) return 0;
            char[] delimiterChars = { ',', ';'};

            numbersString = numbersString.Replace("\n", ",");
            string[] numbers = numbersString.Split(delimiterChars, System.StringSplitOptions.RemoveEmptyEntries);            

            return numbers.Sum(int.Parse);
        }

    }
}

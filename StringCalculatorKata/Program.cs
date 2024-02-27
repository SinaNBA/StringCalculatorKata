using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringCalculatorKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The sum is(with ',') for step1: {Add("1,2,3")}");
            Console.WriteLine($"The sum is(with ',')for step3: {Add("1,\n2,3")}");
            Console.WriteLine($"The sum is(with ',')for step4: {Add("//;\n1;2")}");
            Console.WriteLine($"The sum is(with ',')for step4: {Add("//;\n1;2;-1;-2;-3")}");
        }
        private static int Add(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString)) return 0;
            char[] delimiterChars = { ',', ';' };

            if (numbersString.StartsWith("//")) numbersString = numbersString.Substring(3);

            numbersString = numbersString.Replace("\n", ",");
            string[] numbers = numbersString.Split(delimiterChars, System.StringSplitOptions.RemoveEmptyEntries);

            //to check if there are any negative numbers
            int negativeCount = 0;
            foreach (string number in numbers)
            {
                if (int.Parse(number) < 0) negativeCount++;
            }
            if (negativeCount > 0)
            {
                var negatives = numbers.Where(num => int.Parse(num) < 0).ToList();
                throw new Exception($"negatives not allowed, the negative numbers is: {string.Join(',',negatives)}");
            }

            return numbers.Sum(int.Parse);
        }

    }
}

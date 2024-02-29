using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringCalculatorKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The sum is(with ',') for step1: {Add("1,2,3")}");
            Console.WriteLine($"The sum is(with ',')for step3: {Add("1,\n2,3")}");
            Console.WriteLine($"The sum is(with ',')for step4: {Add("//;\n1;;;2")}");
            //Console.WriteLine($"The sum is(with ',')for step5: {Add("//;\n1;2;-1;-2;-3")}");
            Console.WriteLine($"The sum is(with ',')for step6: {Add("//;\n1;2;1001;1002")}");
            Console.WriteLine($"The sum is(with ',')for step7: {Add("//[***]\n1***2***3")}");
            Console.WriteLine($"The sum is(with ',')for step8: {Add("//[*][%]\n1*2%3")}");
            Console.WriteLine($"The sum is(with ',')for step9: {Add("//[***][%%%]\n1***2%%%3")}");
        }
        private static int Add(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString)) return 0;
            var delimiters = new List<string> { "," };

            if (numbersString.StartsWith("//"))
            {
                var delimiterConfiguration = numbersString.Substring(2, numbersString.IndexOf("\n") - 2);

                if (delimiterConfiguration.StartsWith("[") && delimiterConfiguration.EndsWith("]"))
                {
                    var differentDelimiterCounter = numbersString.Count(n => n == '[');

                    delimiterConfiguration = delimiterConfiguration.Substring(delimiterConfiguration.IndexOf("[") + 1, delimiterConfiguration.LastIndexOf("]") - 1);

                    if (differentDelimiterCounter > 1)
                    {
                        var customDelimiters = delimiterConfiguration.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
                        delimiters.AddRange(customDelimiters);
                    }
                    else
                    {
                        delimiters.Add(delimiterConfiguration);
                    }
                }
                else
                {
                    delimiters.Add(delimiterConfiguration);
                }

                numbersString = numbersString.Substring(numbersString.IndexOf("\n") + 1);
            }

            foreach ( var delimiter in delimiters)
            {
                numbersString = numbersString.Replace(delimiter,",");
            }
            string[] numbers = numbersString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            //to check if there are any negative numbers
            int negativeCount = 0;
            foreach (string number in numbers)
            {
                if (int.Parse(number) < 0) negativeCount++;
            }
            if (negativeCount > 0)
            {
                var negatives = numbers.Where(num => int.Parse(num) < 0).ToList();
                throw new Exception($"negatives not allowed, the negative numbers is: {string.Join(',', negatives)}");
            }

            //to ignore numbers bigger than 1000
            var numbersToSum = numbers.Where(num => int.Parse(num) <= 1000).ToList();
            return numbersToSum.Sum(int.Parse);
        }

    }
}

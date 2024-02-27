namespace StringCalculatorKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The sum is(with ','): {Add("1,\n2,3")}");
            Console.WriteLine($"The sum is(with ';'): {Add2("//;\n1;2")}");
        }
        private static int Add(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString)) return 0;
            char[] delimiterChars = { ',', ';'};

            numbersString = numbersString.Replace("\n", ",");
            string[] numbers = numbersString.Split(delimiterChars, System.StringSplitOptions.RemoveEmptyEntries);            

            //foreach (string number in numbers)
            //{
            //    if(!string.IsNullOrEmpty(number))sum += Convert.ToInt32(number);
            //}

            return numbers.Sum(int.Parse);
        }
        static int Add2(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            string delimiter = ",";
            if (numbers.StartsWith("//"))
            {
                var delimiterLine = numbers.Substring(2, numbers.IndexOf('\n') - 2);
                delimiter = delimiterLine;
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1);
            }

            numbers = numbers.Replace("\n", delimiter);
            var nums = numbers.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return nums.Sum(int.Parse);
        }

    }
}

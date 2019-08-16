using System;

namespace TestDemo
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var numbers = input.Split(',');
            var total = 0;
            foreach (var number in numbers)
            {
                total += TryParseToInteger(number);
            }
            return total;
        }

        private int TryParseToInteger(string input)
        {
            int dest;
            if(!int.TryParse(input, out dest))
            {
                throw new ArgumentException("Input format was incorrect.");
            }
            return dest;
        }
    }
}

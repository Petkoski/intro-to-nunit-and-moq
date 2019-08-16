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
                total += int.Parse(number);
            }
            return total;
        }
    }
}

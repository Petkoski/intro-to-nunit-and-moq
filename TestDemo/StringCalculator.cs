using System;

namespace TestDemo
{
    public class StringCalculator
    {
        private readonly IStore _store;

        public StringCalculator(IStore store)
        {
            _store = store;
        }

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

            //Saving the result if prime.
            //Save() is not implemented
            if(_store != null && IsPrime(total))
            {
                _store.Save(total);
            }

            return total;
        }

        bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number)); //hoisting the loop limit

            for (int i = 2; i <= limit; ++i)
            {
                if (number % i == 0) return false;
            }
            return true;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public class FooController
    {
        private readonly IFoo _foo;

        public FooController(IFoo foo) //Dependency injection
        {
            _foo = foo;
        }

        public bool DoSomething(string value)
        {
            return _foo.DoSomething(value);
        }

        public bool DoSomething(int number, string value)
        {
            return _foo.DoSomething(number, value);
        }

        public bool TryParse(string value, out string outputValue)
        {
            return _foo.TryParse(value, out outputValue);
        }
    }
}
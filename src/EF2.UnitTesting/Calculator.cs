using System;
using System.Collections.Generic;

namespace EF2.UnitTesting
{
    public class Calculator
    {

        private Stack<decimal> stack = new Stack<decimal>();

        public void Push(decimal n1)
        {
            stack.Push(n1);
        }

        public decimal Pop()
        {
            return stack.Pop();
        }

        public decimal Peek()
        {
            return stack.Peek();
        }

        public decimal Add()
        {
            if (stack.Count < 2) throw new ArgumentOutOfRangeException();
            decimal n1 = stack.Pop();
            decimal n2 = stack.Pop();
            return n1 + n2;
        }

    }
}

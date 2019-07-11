using System;
using Xunit;
using FluentAssertions;

namespace EF2.UnitTesting.Tests
{
    public class UnitTest1
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-11)]
        [InlineData(111)]
        [InlineData(123.42)]
        public void AddValueToTheStack(decimal n1)
        {
            var calc = new Calculator();
            calc.Push(n1);
            // nothing to test
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(12, 12)]
        [InlineData(-13.2, -13.2)]
        public void RemoveLastValueFromTheStack(decimal n1, decimal r)
        {
            var calc = new Calculator();
            calc.Push(n1);
            var result = calc.Pop();
            result.Should().Be(r);
        }

        [Theory]
        [InlineData(0, 1, 1, 0)]
        [InlineData(-12, 17.2, 17.2, -12)]
        [InlineData(5, 5, 5, 5)]
        public void RemoveValuesFromStackInProperOrder(decimal n1, decimal n2, decimal r1, decimal r2)
        {
            var calc = new Calculator();
            calc.Push(n1);
            calc.Push(n2);
            calc.Pop().Should().Be(r1);
            calc.Pop().Should().Be(r2);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5.3, 5.3)]
        [InlineData(-6, -6)]
        public void PeekAtLastValue(decimal n1, decimal r1)
        {
            var calc = new Calculator();
            calc.Push(n1);
            calc.Peek().Should().Be(r1);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 3)]
        [InlineData(-283.1, 76.83, -206.27)]
        public void AddTwoNumbers(decimal n1, decimal n2, decimal r1)
        {
            var calc = new Calculator();
            calc.Push(n1);
            calc.Push(n2);
            calc.Add().Should().Be(r1);
        }

        [Theory]
        [InlineData()]
        [InlineData(101)]
        public void AddWithoutEnoughNumbers(params int[] args)
        {
            var calc = new Calculator();
            for (int j = 0; j < args.Length; j++)
            {
                calc.Push(args[j]);
            }
            calc.Invoking(c => c.Add()).Should().Throw<ArgumentOutOfRangeException>();
        }

    }
}

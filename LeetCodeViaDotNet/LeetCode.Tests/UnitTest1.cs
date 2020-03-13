using System;
using Xunit;
using LeetCodeLab;

namespace LeetCode.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2,2)]
        [InlineData(4,5)]
        //[InlineData(30,832040)]
        //[InlineData(31,-1)]
        public void Sol70_ClimbStairsTest(int input,int expected)
        {
            Solution70 sol = new Solution70();
            var actual = sol.ClimbStairs(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4,3)]
        [InlineData(10,55)]
        [InlineData(30,832040)]
        [InlineData(31,-1)]
        public void Sol509_FibonacciTest(int input,int expected)
        {
            Solution509 sol = new Solution509();
            var actual = sol.Fib(input);
            Assert.Equal(expected, actual);
        }
    }
}

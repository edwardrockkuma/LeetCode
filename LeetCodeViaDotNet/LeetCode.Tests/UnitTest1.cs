using System;
using Xunit;
using LeetCodeLab;
using System.Collections.Generic;

namespace LeetCode.Tests
{
    public class UnitTest1
    {
        [Theory]
        [MemberData(nameof( IsValidData_74))]       
        public void Sol74_Search2DMatrix(TestCase testCase,bool expected,string description)
        {
            Solution74 sol = new Solution74(testCase);
            //var actual = sol.Search2DMatrix(input);
            Assert.True( testCase.IsValid == expected,description);
        }

        public static IEnumerable<object[]> IsValidData_74
        {
            get
            {
               
                var data= new List<ITheoryDatum>();

                data.Add(TheoryDatum.Factory(new TestCase( new object[] {new int[3][] { new int[]{1, 3, 5, 7}, new int[]{10, 11, 16, 20},new int[]{23, 30, 34, 50}},34 }),true,"ok"));
                data.Add(TheoryDatum.Factory(new TestCase( new object[] {new int[3][] { new int[]{1, 3, 5, 7}, new int[]{10, 11, 16, 20},new int[]{23, 30, 34, 50}},21}) , false, "missing"));              
                // Edge Case
                data.Add(TheoryDatum.Factory(new TestCase( new object[] {new int[][] { null } ,21 }) , false, "missing"));          
                data.Add(TheoryDatum.Factory(new TestCase( new object[] {new int[][] { new int[]{ 1 } },1}) , true, "ok")); 
                return data.ConvertAll(d => d.ToParameterArray());
            }
        }
        

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

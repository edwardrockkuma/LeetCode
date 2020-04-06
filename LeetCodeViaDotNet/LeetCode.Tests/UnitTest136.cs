using System;
using Xunit;
using LeetCodeLab;
using System.Collections.Generic;

namespace LeetCode.Tests
{
    public class UnitTest136
    {
        [Theory]
        [MemberData(nameof( IsValidData_136))]       
        public void Sol136_SingleNum(TestCase testCase)
        {
            Solution136 sol = new Solution136(testCase);
            //var actual = sol.Search2DMatrix(input);
            Assert.True( testCase == expected);
        }

        public static IEnumerable<object[]> IsValidData_136
        {
            get
            {
               
                var data= new List<ITheoryDatum>();

                data.Add(TheoryDatum.Factory(new TestCase( new object[] { new int[]{2, 2, 1}}),1));
                data.Add(TheoryDatum.Factory(new TestCase( new object[] { new int[]{4, 1, 2, 1, 2}}),4));
                            
                // Edge Case
                //data.Add(TheoryDatum.Factory(new TestCase( new object[] {new int[][] { null } ,21 }) , false, "missing"));          
                //data.Add(TheoryDatum.Factory(new TestCase( new object[] {new int[][] { new int[]{ 1 } },1}) , true, "ok")); 
                return data.ConvertAll(d => d.ToParameterArray());
            }
        }
    }
}
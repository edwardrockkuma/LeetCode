using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLab
{
    /// <summary>
    /// TwoSum - LeetCode
    /// </summary>
    public class Solution1
    {
        public int[] _nums { get; set; }
        public int _target { get; set; }

        public int[] _results { get; set; }

       

        public int[] TwoSum(int[] nums, int target)
        {
            // key:array value  , value: array idx
            Dictionary<int, int> tempMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int result = target - nums[i];
                if (tempMap.ContainsKey(result))
                {
                    int idx = -1;
                    tempMap.TryGetValue(result, out idx);

                    return new int[] { idx, i };
                }
                tempMap.TryAdd(nums[i], i);

            }

            throw new Exception("No solution");
        }

        public void Execute()
        {
            try
            {

                var answers = TwoSum(_nums, _target);
                _results = answers;
                Console.WriteLine($"answers: {JsonConvert.SerializeObject(answers)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"excption: {ex.Message}");
                throw;
            }
        }
    }

    /// <summary>
    /// BinaryGap - Codility , date: 20200304, Time complexity issue founded
    /// [Q]:A binary gap within a positive integer N is any maximal sequence of consecutive zeros 
    /// that is surrounded by ones at both ends in the binary representation of N.
    /// Write a function: that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.
    /// Write an efficient algorithm for the following assumptions:
    /// N is an integer within the range[1..2, 147, 483, 647].
    /// </summary>
    public class BinaryGap
    {
        public int FindMaxGap(int N )
        {
            bool started = false;
            int length = 0, max = 0;
            // Tips: uint & bit operator 
            for (uint i = 1; i <= N; i<<=1)
            {
                if((i & N) != 0)
                {
                    if(started)
                    {
                        if(length > max)
                        {
                            max = length;
                        }
                        length = 0;
                    }

                    started = true;
                }
                else if(started)
                {
                    length++;
                    Console.WriteLine($"started:i:{i} , length: {length}");
                }
                //Console.WriteLine(i);
            }

            return max;
        }
    }
}

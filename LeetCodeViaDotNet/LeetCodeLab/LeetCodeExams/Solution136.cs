using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeLab.LeetCodeExams
{
    /// <summary>
    /// Given a non-empty array of integers, every element appears twice except for one. Find that single one.
    /// * Note:
    /// * Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
    /// </summary>
    public class Solution136
    {
        public int[] _nums { get; set; }

        public int _output { get; set; }

        public Solution136(TestCase testData)
        {
            _nums = testData._parameters[0] as int[];
            //_output = (int)(testData._parameters[1]);
            
            testData.IsValid = SingleNumber(_nums).Equals(_output);
        }

        public int SingleNumber(int[] nums) 
        {
            // key: number in array, value: repeat counts
            Dictionary<int , int> maps = new Dictionary<int, int>();
            // Time: O(N) Space: O(n/2)
            foreach(var num in nums)
            {
                if(maps.ContainsKey(num))
                {
                    maps[num] += 1;
                }
                else
                {
                    maps.Add(num,1);
                }
            }

            if(maps.ContainsValue(1))
            {
                var kvp = maps.FirstOrDefault(x => x.Value == 1);
                
                return kvp.Key;   
            }
            else
            {
                return 0;
            }
        }
    }
}
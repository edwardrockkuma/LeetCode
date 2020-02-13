using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
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
}

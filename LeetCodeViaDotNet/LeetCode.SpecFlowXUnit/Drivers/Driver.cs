using System;
using System.Collections.Generic;
using LeetCodeLab;

namespace LeetCode.SpecFlowXUnit.Drivers
{
    public class Driver1
    {
        private Solution1 _sol;

        public void CreateBackground(string nums) 
        {
            _sol = new Solution1();
            List<int> temp = new List<int>();
            foreach (string num in nums.Trim().Split(','))
            {
                temp.Add(int.Parse(num));
            }
            _sol._nums = temp.ToArray();
        }

        public void SetTarget(int target)
        {
            _sol._target = target;
        }

        public void ExecuteAction() 
        {
            _sol.Execute();
        }

        public bool CheckCondition(string results) 
        {
            //List<int> temp = new List<int>();
            //int matchedCounter = 0;
            int idx = 0;
            foreach (string num in results.Trim().Split(','))
            {
                if(_sol._results[idx] != int.Parse(num))
                {
                    return false;
                }
                

                idx += 1;
            }

            return true;
        }

    }
}

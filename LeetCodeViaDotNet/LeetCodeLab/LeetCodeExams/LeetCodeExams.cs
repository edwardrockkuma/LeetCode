﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace LeetCodeLab
{
    // TODO: Split the Solutions into Groups by different type. Ex: Divide & Conquer

    /// <summary>
    /// A Reusable Test Model
    /// </summary>
    public class TestCase
    {
        public bool IsValid { get; set; }
        public object[] _parameters { get; set; }

        public TestCase(object[] parameters)
        {
            _parameters = parameters;
        }

        
    }

    public class ArrayHelper{
        //  public int[][] ConvertToJaggedArray(object objArr)
        // {
        //     objArr.Select(line => line
        //     .Select(item => item.ToString())
        //     .ToArray())
        //     .ToArray();
        // }
    }
   

    /// <summary>
    /// 74. Search a 2D Matrix - Medium
    /// Write an efficient algorithm that searches 
    /// for a value in an m x n matrix. This matrix has the following properties:
    /// * Integers in each row are sorted from left to right.
    /// * The first integer of each row is greater than the last integer of the previous row.
    /// </summary>
    public class Solution74
    {
        private int[][] _matrix { get; set;}
        private int _target { get; set; }

        public Solution74( TestCase data)
        {
            _matrix = data._parameters[0] as int[][]; 
            _target = (int)(data._parameters[1]);
            data.IsValid = SearchMatrix(_matrix , _target);
        }

        public bool SearchMatrix(int[][] matrix, int target) 
        {
            /*
                1. from the max value in every row , if target > max , then go next row
                2. loop 
                Two-dimensional GetLength example:
                int[,] two = new int[5, 10];
                Console.WriteLine(two.GetLength(0)); // Writes 5
                Console.WriteLine(two.GetLength(1)); // Writes 10
                Console.WriteLine(two.Length);  // Writes 50
            */
            int total = matrix.Length;
            if(total == 0)
                return false;

            int rowsOrHeight = matrix.GetLength(0);
           // int colsOrWidth = total / rowsOrHeight;
            int colsOrWidth = matrix[0].Length;
            int colIdx = colsOrWidth-1;
            int rowIdx = 0;
            int value = 0;
            while(rowIdx < rowsOrHeight && colIdx >= 0)
            {
                value = matrix[rowIdx][colIdx];
                if(target  == value)
                {
                   return true;                  
                }
                else if(value > target)
                {
                    colIdx -= 1;
                  
                }
                else
                {
                    rowIdx += 1;
                    colIdx = colsOrWidth-1;
                }
            }
            return false;
        }
    }
 
    /// <summary>
    /// 70. Climbing Stairs - easy
    /// You are climbing a stair case. It takes n steps to reach to the top.
    /// Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
    /// Note: Given n will be a positive integer.
    /// Tips: advanced Fibonacci
    ///   f(1) = 1 , f(2) = 2 , f(3) = f(2) + f(1) , f(4) = f(3) + f(2)
    //  analyze: we can divide to 2 ways:  A. 最後差一步 + B.最後差兩步
    ///   f(n) = f(n-1) + f(n-2) 
    /// </summary>
    public class Solution70
    {
        public int ClimbStairs(int n) 
        {
            int result = 0;
            if(n == 1)
                return 1;

            if(n == 2)
                return 2; 
            int big = 2;
            int small = 1;
           
            for(int i = 3; i < n+1 ; i++)
            {
                
                result = big + small;
                small = big;
                big = result;
                
            }   

            return result;  
        }
    }

    /// <summary>
    /// Fibonacci Number - easy
    /// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1.
    /// 0 ≤ N ≤ 30.
    /// </summary>
    public class Solution509
    {
        public int Fib(int N) 
        {
            if(N < 0 || N > 30)
                return -1;

            int result = 0;
            if(N == 0)
                return result;

            if(N == 1)
            {
                result = 1;
                return result;
            }


            int big = 0;
            int small = 0;  
                        
            for(int i = 2; i <= N; i++)
            {
                if(i == 2)
                {
                    big = i-1;
                    small = i-2;
                }
                else
                {
                    small = big;
                    big = result;                  
                }
                                
                result = big + small;
                 
            }

            return result;
        }
    } 

    /// <summary>
    /// TwoSum - LeetCode
    /// Tips: Hash or Dictionary
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
    /// Valid Parenthese -LeetCode
    /// Tips: Stack
    /// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    // An input string is valid if:
    // Open brackets must be closed by the same type of brackets.
    // Open brackets must be closed in the correct order.
    // Note that an empty string is also considered valid.
    /// </summary>
    public class Solution77
    {
        public bool IsValid(string targetStr)
        {
            if(string.IsNullOrEmpty(targetStr))
            {
                return true;
            }

            Dictionary<Char , Char> container = new Dictionary<char, char>();
            container.Add(')','('); 
            container.Add('}','{');
            container.Add(']','[');
            Stack<Char> tempStack = new Stack<Char>();
            int length = targetStr.Length;
            
            if(length % 2 == 1)
            {
                return false;
            }

            for(int i=0; i < length ; i++)
            {
                Char charNow = targetStr[i];
                if(container.ContainsValue(charNow) )
                {
                    tempStack.Push(charNow);
                }
                else
                {
                    if(tempStack.Count == 0)
                    {
                        return false;
                    }

                    if(tempStack.Peek() == container[charNow])
                    {
                        tempStack.Pop();
                    }
                }
                
                
                //Console.WriteLine(charNow);
            }
            
            return tempStack.Count == 0;
        }
    }

    /// <summary>
    // Tips: Recursive
    ///  Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
    // For example, given n = 3, a solution set is:
    /* 
    [
        "((()))",
        "(()())",
        "(())()",
        "()(())",
        "()()()"
    ] 
    */
    /// </summary>
    public class Solution22 {
        public IList<string> GenerateParenthesis(int n) {
            List<string> results = new List<string>();
            string ans = "";
            Generator(n , n , ans);
            foreach(var str in container)
            {
                results.Add(str);
            }
            results.Reverse();

            return results;
        }
        Stack<string> container = new Stack<string>();

        private void Generator(int left , int right , string str)
        {
            if(left == 0 && right == 0)
            {
                container.Push(str);
                Console.WriteLine($"final , str:{str}");
            }

            if(left > 0)
            {
                Console.WriteLine($"left:{left} , str:{str}");
                Generator(left-1 , right , str+'(');
                
            }

            if(right > 0 && left < right)
            {
                Console.WriteLine($"right:{right} , str:{str}");
                Generator(left , right -1 , str+')');
            }
        } 

        public void Execute()
        {
            var ans = GenerateParenthesis(3);
        }
    }

    /// <summary>
    /// BinaryGap - Codility , date: 20200304, Time complexity issue founded
    /// Tips: Bit operator (<<)
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
            try 
            {

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
                    ++length;
                    //Console.WriteLine($"started:i:{i} , length: {length}");
                }
                //Console.WriteLine(i);
            }

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.WriteLine($"Max: {max}");
            return max;
        }
    }



}

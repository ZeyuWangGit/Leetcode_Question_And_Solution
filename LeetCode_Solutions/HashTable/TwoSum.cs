using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.HashTable
{
    [TestClass]
    public class TwoSum
    {
        [TestMethod]
        public void TwoSum_ShouldPass()
        {
            GetTwoSum(new []{ 2, 7, 11, 15 }, 9).ShouldBe(new []{0 ,1});
        }

        public int[] GetTwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var match = target - nums[i];
                if (dict.ContainsKey(match))
                {
                    return new[] {dict[match], i};
                }

                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
                
            }
            throw new Exception("No two sum solution");
        }
    }
}

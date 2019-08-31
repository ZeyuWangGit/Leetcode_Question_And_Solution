using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;


namespace LeetCode_Solutions.HashTable
{

    /*
     *  Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
     */
    [TestClass]
    public class ThreeSum
    {
        [TestMethod]
        public void ThreeSum_ShouldPass()
        {
            var source = new int[]{ -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> result = new int[][] { new int[]{ -1, 0, 1 }, new int[]{ -1, -1, 2 } };
            GetThreeSum(source).ShouldBe(result);

            var source1 = new int[] {1, 2, -2, -1};
            IList<IList<int>> result1 = new List<IList<int>>();
            GetThreeSum(source1).ShouldBe(result1);
        }

        public IList<IList<int>> GetThreeSum(int[] nums)
        {
            if (nums.Length < 3)
            {
                return new List<IList<int>>();
            }
            Array.Sort(nums);
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                GetTwoSum(nums, i + 1, nums[i] * -1, set);
            }
            
            List<List<int>> temp = new List<string>(set).ConvertAll(element => element.Split(',').Select(int.Parse).ToList());
            

            return temp.Cast<IList<int>>().ToList();
        }

        public void GetTwoSum(int[] nums, int startIndex, int target, HashSet<string> set)
        {
            var dict = new Dictionary<int, int>();
            for (int i = startIndex; i < nums.Length; i++)
            {
                var match = target - nums[i];
                if (dict.ContainsKey(match))
                {
                    var innerList = new List<int> {target * -1, match, nums[i]};
                    innerList.Sort();
                    set.Add(string.Join(",", innerList.ToArray()));
                }

                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
        }
    }
}

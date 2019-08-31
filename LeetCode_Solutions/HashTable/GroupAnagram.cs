using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.HashTable
{
    [TestClass]
    public class GroupAnagram
    {
        [TestMethod]
        public void GroupAnagram_ShouldPass()
        {
            var testCases = new string[]{ "eat", "tea", "tan", "ate", "nat", "bat"};
            var expected = new List<IList<string>>()
            {
                new List<string>(){ "eat", "tea", "ate" },
                new List<string>(){ "tan", "nat" },
                new List<string>(){ "bat" }
            };
            GroupAnagrams(testCases).ShouldBe(expected);
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            List<IList<string>> results = new List<IList<string>>();
            foreach (var str in strs)
            {
                var sortedStr = new string(str.OrderBy(c => c).ToArray());
                if (!dict.ContainsKey(sortedStr))
                {
                    dict.Add(sortedStr, new List<string>(){str}); 
                }
                else
                {
                    dict[sortedStr].Add(str);
                }
            }

            foreach (KeyValuePair<string, List<string>> entry in dict)
            {
                results.Add(entry.Value);
            }
            
            return results;

        }

        
    }
}

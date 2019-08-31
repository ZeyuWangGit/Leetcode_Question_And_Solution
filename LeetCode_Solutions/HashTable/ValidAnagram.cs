using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.HashTable
{
    [TestClass]
    public class ValidAnagram
    {
        [TestMethod]
        public void ValidAnagram_ShouldPass()
        {
            IsAnagramWithSorting("anagram", "nagaram").ShouldBe(true);
            IsAnagramWithSorting("rat", "cat").ShouldBe(false);
            IsAnagramWithHash("anagram", "nagaram").ShouldBe(true);
            IsAnagramWithHash("rat", "cat").ShouldBe(false);
        }

        public bool IsAnagramWithSorting(string s, string t)
        {
            var sArray = s.ToCharArray();
            var tArray = t.ToCharArray();
            Array.Sort(sArray);
            Array.Sort(tArray);
            return sArray.SequenceEqual(tArray);
        }

        public bool IsAnagramWithHash(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var tArray = t.ToCharArray();
            var sArray = s.ToCharArray();
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(tArray[i]))
                {
                    dict[tArray[i]] = dict.GetValueOrDefault(tArray[i]) + 1;
                }
                else
                {
                    dict.Add(tArray[i], 1);
                }

                if (dict.ContainsKey(sArray[i]))
                {
                    dict[sArray[i]] = dict.GetValueOrDefault(sArray[i]) - 1;
                }
                else
                {
                    dict.Add(sArray[i], -1);
                }

            }

            foreach (var item in dict)
            {
                if (item.Value != 0)
                {
                    return false;
                }
            }

            return true;

        }
    }
}

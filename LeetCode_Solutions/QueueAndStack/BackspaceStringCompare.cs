using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.QueueAndStack
{
    [TestClass]
    public class BackspaceStringCompare
    {
        [TestMethod]
        public void BackSpaceStringCompare_shouldPass()
        {
            BackspaceCompare("ab#c", "ad#c").ShouldBe(true);
            BackspaceCompare("a##c", "#a#c").ShouldBe(true);
            BackspaceCompare("a#c", "b").ShouldBe(false);
        }
        public bool BackspaceCompare(string S, string T)
        {
            return BackspaceStringBuilder(S).Equals(BackspaceStringBuilder(T));
        }

        public string BackspaceStringBuilder(string S)
        {
            Stack<char> str = new Stack<char>();
            foreach (var c in S)
            {
                if (c!='#')
                {
                    str.Push(c);
                }
                else if (str.Count > 0)
                {
                    str.Pop();
                }
            }
            return string.Join("", str.ToArray());
        }
    }
}

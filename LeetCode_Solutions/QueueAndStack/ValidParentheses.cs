using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.QueueAndStack
{
    [TestClass]
    public class ValidParentheses
    {
        [TestMethod]
        public void ValidParentheses_ShouldPass()
        {
            IsValid("()").ShouldBe(true);
            IsValid("()[]{}").ShouldBe(true);
            IsValid("(]").ShouldBe(false);
            IsValid("([)]").ShouldBe(false);
            IsValid("{[]}").ShouldBe(true);
        }
        public bool IsValid(string s)
        {
            var mapping = new Dictionary<char, char> {{')', '('}, {'}', '{'}, {']', '['}};
            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (mapping.ContainsKey(c))
                {
                    var top = stack.Count < 1 ? '#' : stack.Pop();
                    if (top != mapping[c])
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            return stack.Count < 1;

        }
    }
}

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.QueueAndStack
{
    [TestClass]
    public class ImplementQueueUsingStacks
    {
        [TestMethod]
        public void ImplemtnQueueUsingStacks_ShouldPass()
        {
            MyQueue queue = new MyQueue();

            queue.Push(1);
            queue.Push(2);
            queue.Peek().ShouldBe(1);  // returns 1
            queue.Pop().ShouldBe(1);   // returns 1
            queue.Empty().ShouldBe(false); // returns false

        }
    }

    public class MyQueue
    {
        private Stack<int> stack_1;

        private Stack<int> stack_2;

        private int peek;
        /** Initialize your data structure here. */
        public MyQueue()
        {
            this.stack_1 = new Stack<int>();
            this.stack_2 = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            if (stack_1.Count < 1)
            {
                peek = x;
            }
            this.stack_1.Push(x);
            
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            int tempPeek = peek;
            while (stack_1.Count > 1)
            {
                peek = stack_1.Pop();
                stack_2.Push(peek);
            }

            stack_1.Pop();
            while (stack_2.Count > 0)
            {
                stack_1.Push(stack_2.Pop());
            }

            return tempPeek;
        }

        /** Get the front element. */
        public int Peek()
        {
            return peek;
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return stack_1.Count < 1;
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */
}

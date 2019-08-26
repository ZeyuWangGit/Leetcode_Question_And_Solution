using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.QueueAndStack
{
    [TestClass]
    public class ImplementStackUsingQueues
    {
        /**
         * Your MyStack object will be instantiated and called as such:
         * MyStack obj = new MyStack();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Top();
         * bool param_4 = obj.Empty();
         *
         * */

        [TestMethod]
        public void ImplemtnStackUsingQueue_ShouldPass()
        {
            MyStack stack = new MyStack();

            stack.Push(1);
            stack.Push(2);
            stack.Top().ShouldBe(2);   // returns 2
            stack.Pop().ShouldBe(2);   // returns 2
            stack.Empty().ShouldBe(false); // returns false

        }


    }

    public class MyStack
    {
        private Queue<int> queue;
        private Queue<int> tempQueue;
        private int top;

        /** Initialize your data structure here. */
        public MyStack()
        {
            this.queue = new Queue<int>();
            this.tempQueue = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            queue.Enqueue(x);
            top = x;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            int tempTop = top;
            while(queue.Count > 1)
            {
                top = queue.Dequeue();
                tempQueue.Enqueue(top);
            }

            queue.Dequeue();
            Queue<int> temp = queue;
            queue = tempQueue;
            tempQueue = temp;
            return tempTop;
        }

        /** Get the top element. */
        public int Top()
        {
            return top;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return queue.Count < 1;
        }
    }
}

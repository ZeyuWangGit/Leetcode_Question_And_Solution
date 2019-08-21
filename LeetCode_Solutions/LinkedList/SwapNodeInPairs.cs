using LeetCode_Solutions.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.LinkedList
{
    /*
     *  Given a linked list, swap every two adjacent nodes and return its head.
     *  You may not modify the values in the list's nodes, only nodes itself may be changed.
     *
     *  Given 1->2->3->4, you should return the list as 2->1->4->3.
     */

    [TestClass]
    public class SwapNodeInPairs
    {
        [TestMethod]
        public void LinkedListSwapNodeInPairs_WithNormalCase()
        {

            var originLists = ListNodeHelpers.CreateLinkedList(new int[4] { 1, 2, 3, 4 });
            var result = ListNodeHelpers.CreateLinkedList(new int[4] { 2, 1, 4, 3 });
            ListNodeHelpers.ListToString(SwapNodeInPairsWithRecursion(originLists)).ShouldBe(ListNodeHelpers.ListToString(result));
        }
        public ListNode SwapNodeInPairsWithRecursion(ListNode head)
        {
            if (head?.next == null) return head;
            var p = SwapNodeInPairsWithRecursion(head.next.next);
            var n2 = head.next;
            n2.next = head;
            head.next = p;
            return n2;
        }
    }
}

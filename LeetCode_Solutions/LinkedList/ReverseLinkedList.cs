using LeetCode_Solutions.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.LinkedList
{
    /**
        Reverse a singly linked list.

        Example:
        Input: 1->2->3->4->5->NULL
        Output: 5->4->3->2->1->NULL
    **/

    [TestClass]
    public class ReverseLinkedList
    {
        
        [TestMethod]
        public void LinkedListShouldReverse_WithNormalCase()
        {

            var originLists = ListNodeHelpers.CreateLinkedList(new int[5] { 1, 2, 3, 4, 5 });
            var result = ListNodeHelpers.CreateLinkedList(new int[5] {5, 4, 3, 2, 1});
            ListNodeHelpers.ListToString(ReverseList(originLists)).ShouldBe(ListNodeHelpers.ListToString(result));

        }
        [TestMethod]
        public void LinkedListShouldReverse_WithRecursion()
        {

            var originLists = ListNodeHelpers.CreateLinkedList(new int[5] { 1, 2, 3, 4, 5 });
            var result = ListNodeHelpers.CreateLinkedList(new int[5] { 5, 4, 3, 2, 1 });
            ListNodeHelpers.ListToString(ReverseListWithRecursion(originLists)).ShouldBe(ListNodeHelpers.ListToString(result));

        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;
            ListNode current = head;
            while (current != null)
            {
                var tempNode = current.next;
                current.next = pre;
                pre = current;
                current = tempNode;
            }

            return pre;
        }

        private ListNode ReverseListWithRecursion(ListNode head)
        {
            if (head?.next == null) return head;

            var p = ReverseListWithRecursion(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }

    }

    
}

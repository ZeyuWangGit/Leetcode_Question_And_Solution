using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions
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

            var originLists = CreateLinkedList(new int[5] { 1, 2, 3, 4, 5 });
            var result = CreateLinkedList(new int[5] {5, 4, 3, 2, 1});
            ListToString(ReverseList(originLists)).ShouldBe(ListToString(result));
            
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

        private ListNode CreateLinkedList(int[] values)
        {
           var head = new ListNode(values[0]);
           var current = head;
           for (int i = 1; i < values.Length; i++)
           {
               current.next = new ListNode(values[i]);
               current = current.next;
           }
           return head;
        }

        private string ListToString(ListNode node)
        {
            var result = "";
            var current = node;
            while (current != null)
            {
                result += current.val;
                current = current.next;
            }

            return result;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

    }

    
}

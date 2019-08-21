using LeetCode_Solutions.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions
{
    /*
     *  Given a linked list, determine if it has a cycle in it.
     *  To represent a cycle in the given linked list, we use an integer pos
     *  which represents the position (0-indexed) in the linked list where tail connects to.
     *  If pos is -1, then there is no cycle in the linked list.
       
       
     */

    [TestClass]
    public class LinkedListCycle
    {
        [TestMethod]
        public void LinkedListCycle_HasCycle()
        {
            var list = ListNodeHelpers.CreateCycleLinkedList(new int[4] {3, 2, 0, -4}, 1);
            HasCycle(list).ShouldBe(true);
            var list_1 = ListNodeHelpers.CreateCycleLinkedList(new int[2] { 1, 2 }, 0);
            HasCycle(list_1).ShouldBe(true);
            var list_2 = ListNodeHelpers.CreateCycleLinkedList(new int[1] { 1 }, -1);
            HasCycle(list_2).ShouldBe(false);

        }
        public bool HasCycle(ListNode head)
        {
            if (head?.next == null) return false;
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow!=fast)
            {
                if (fast?.next == null) return false;
                slow = slow.next;
                fast = fast.next.next;
            }

            return true;

        }
    }
}
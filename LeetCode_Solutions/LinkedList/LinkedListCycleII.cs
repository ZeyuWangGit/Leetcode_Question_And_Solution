using LeetCode_Solutions.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LeetCode_Solutions.LinkedList
{
    [TestClass]
    public class LinkedListCycleII
    {
        [TestMethod]
        public void LinkedListCycle_HasCycle()
        {
            var list = ListNodeHelpers.CreateCycleLinkedList(new int[4] {3, 2, 0, -4}, 1);
            DetectCycle(list).val.ShouldBe(2);
            var list_1 = ListNodeHelpers.CreateCycleLinkedList(new int[2] { 1, 2 }, 0);
            DetectCycle(list_1).val.ShouldBe(1);
            var list_2 = ListNodeHelpers.CreateCycleLinkedList(new int[1] { 1 }, -1);
            DetectCycle(list_2).ShouldBe(null);

        }
        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            ListNode start = head;
            while (fast?.next!=null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    while (slow!=start)
                    {
                        slow = slow.next;
                        start = start.next;
                    }

                    return start;
                }
            }
            return null;
        }
    }
}
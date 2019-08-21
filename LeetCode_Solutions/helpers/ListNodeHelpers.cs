namespace LeetCode_Solutions.helpers
{
    public static class ListNodeHelpers
    {
        public static ListNode CreateLinkedList(int[] values)
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

        public static string ListToString(ListNode node)
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
    }
}

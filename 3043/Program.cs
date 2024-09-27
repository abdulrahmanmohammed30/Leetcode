namespace _3043
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LongestCommonPrefix([1, 10, 100], [1000]));
        }
    }
    public class Solution
    {
        public int LongestCommonPrefix(int[] arr1, int[] arr2)
        {
            var root = BuildTrie(arr2);
            var res = 0;
            var st = new Stack<int>();

            foreach (var number in arr1)
            {
                var temp = number;
                while (temp > 0)
                {
                    st.Push(temp % 10);
                    temp /= 10;
                }
                int counter = 0;
                DFS(root, st, ref counter);
                res = Math.Max(res, counter);
                st.Clear();
            }
            return res;
        }

        public void DFS(Node node, Stack<int>st, ref int counter)
        {
            if (!st.TryPop(out int val) || node.children[val] == null)
            {
                return;
            }

            counter++;
            node = node.children[val];
            DFS(node, st, ref counter);
        }

        public Node BuildTrie(int[] numbers)
        {
            Node root = new Node();
            var st = new Stack<int>();
            foreach (var number in numbers)
            {
                var temp = number;
                while (temp > 0)
                {
                    st.Push(temp % 10);
                    temp /= 10;
                }
                Node node = root;
                while (true)
                {
                    if (!st.TryPop(out int cur)) break;

                    if (node.children[cur] == null)
                        node.children[cur] = new Node();
                    node = node.children[cur];
                }
            }
            return root;
        }

        public class Node
        {
            public Node[] children = new Node[10];
            public int? number;
        }
    }
}

using System.Runtime.ConstrainedExecution;

namespace _421
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().FindMaximumXOR([14, 70, 53, 83, 49, 91, 36, 80, 92, 51, 66, 70]));
            Console.ReadLine();
        }

        static public void ToBinary (int number)
        {

            var temp = number;

            while (temp > 0)
            {
                Console.WriteLine(temp % 2);
                temp /= 2;
            }

        }
    }

    public class Solution
    {
        const int MaxNumberOfDigits = 31;
        public int FindMaximumXOR(int[] nums)
        {
            var root = BuildTrie(nums);
            var res = 0;
            foreach (var number in nums)
            {
                var q = new Stack<int>();
                var temp = number;

                while (temp > 0)
                {
                    int x = temp % 2;
                    q.Push(temp % 2);
                    temp /= 2;
                }
           

                int RemainingDigitsToAppend = MaxNumberOfDigits - q.Count();
                while (RemainingDigitsToAppend > 0)
                {
                    q.Push(0);
                    RemainingDigitsToAppend--;
                }

                int maxVal = 0;
                DFS(root, q, ref maxVal, MaxNumberOfDigits);
                res = Math.Max(res, maxVal);
            }
            return res;
        }

        public void DFS(Node node, Stack<int> q, ref int maxVal, int pos)
        {
            if (pos <= 0)
                return;

            int digit = q.Pop();

            if (node.children[digit ^ 1] != null)
            {
                maxVal += (int)Math.Pow(2, pos-1);
                node = node.children[digit ^ 1];
            }
            else
            {
                node = node.children[digit];
            }

            pos--;
            DFS(node, q, ref maxVal,  pos);
        }

        public Node BuildTrie(int[] numbers)
        {
            Node root = new Node();
            var q = new Stack<int>();
            foreach (var number in numbers)
            {
                var temp = number;
                while (temp > 0)
                {
                    q.Push(temp % 2);
                    temp /= 2;
                }
                Node node = root;
                int RemainingDigitsToAppend= MaxNumberOfDigits - q.Count();
                while (RemainingDigitsToAppend > 0)
                {
                    if (node.children[0] == null)
                        node.children[0] = new Node();
                    node = node.children[0];
                    RemainingDigitsToAppend--;
                }
                while (true)
                {
                    if (!q.TryPop(out int cur)) break;

                    if (node.children[cur] == null)
                        node.children[cur] = new Node();
                    node = node.children[cur];
                }
            }
            return root;
        }

        public class Node
        {
            public Node[] children = new Node[2];
            public int? number;
        }
    }
}

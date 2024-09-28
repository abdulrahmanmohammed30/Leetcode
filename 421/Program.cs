using System.Runtime.ConstrainedExecution;

namespace _421
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number = 15;
            for(int i=31;i >=0;i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(new Solution().FindMaximumXOR([14, 70, 53, 83, 49, 91, 36, 80, 92, 51, 66, 70]));
            Console.ReadLine();
        }
    }



    public class Solution
    {
        public readonly int maxBits = 31;

        public int FindMaximumXOR(int[] nums)
        {
            if (nums.Length == 1) return 0;

            var root = BuildTrie(nums);
            var res = 0;
            foreach (var number in nums)
            {
                var currentNode = root;
                var xorNode = root;
                int curMax = 0;

                for(int i=maxBits;i >=0;i--)
                {
                    int bit = (number >> i) & 1;

                    if (xorNode.children[bit ^ 1] != null)
                    {
                        curMax |= (1 << i);
                        xorNode = xorNode.children[bit ^ 1];
                    }
                    else
                    {
                        xorNode = xorNode.children[bit];
                    }
                }
                res = Math.Max(res, curMax);
            }
            return res;
        }

    
        public Node BuildTrie(int[] numbers)
        {
            Node root = new Node();
            foreach (var number in numbers)
            {
                Node node = root;

                for (int i=maxBits;i>=0;i--)
                {
                    int bit = (number >> i) & 1;
                    if (node.children[bit] == null)
                        node.children[bit] = new Node();
                    node = node.children[bit];
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

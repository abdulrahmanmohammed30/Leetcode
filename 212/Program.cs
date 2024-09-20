namespace _212_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Solution
    {


        public Node BuildTrie(string[] words) {
            Node root = new Node();
            foreach(var word in words)
            {
                Node node = root;
                foreach(var ch in word)
                {
                    if (node.children[ch-'a']==null)
                    {
                        node.children[ch - 'a'] = new Node();
                    }
                    node = node.children[ch-'a']; 
                }
                node.word = word;
            }
            return root;
        }
        
        public class Node
        {
            public Node[] children=new Node[26];
            public string? word;
        }
    }
}

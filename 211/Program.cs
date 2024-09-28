using System.Numerics;

namespace _211
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class WordDictionary
    {
        Node root;
        public WordDictionary()
        {
            root = new Node();
        }

        public bool Search(string word)
        {
            return SearchWord(root, word, 0, word.Length);
        }

        private bool SearchWord(Node node, string word, int index, int size)
        {
            if (!string.IsNullOrEmpty(node.word) && index==size) return true;

            if (index == size) return false;

            char ch = word[index++];

            if (ch == '.')
            {
                for (int i = 0; i < 26; i++)
                {
                    if (node.children[i] != null)
                    {
                        if (SearchWord(node.children[i], word, index, size)) return true;
                    }
                }
                return false;
            }
            if (node.children[ch-'a'] == null) return false;
            if (SearchWord(node.children[ch - 'a'], word, index, size)) return true;
            return false;
        }

        public void AddWord(string word)
        {
            Node node = root;
            foreach (var ch in word)
            {
                if (node.children[ch - 'a'] == null)
                {
                    node.children[ch - 'a'] = new Node();
                }
                node = node.children[ch - 'a'];
            }
            node.word = word;
        }

        public class Node
        {
            public Node[] children = new Node[26];
            public string? word;
        }
    }
}

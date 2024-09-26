using System.Drawing;
using System;
using System.Text;
using System.Reflection;

namespace _139
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaab\"", ["a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa"]));
        }
    }

    public class Solution
    {

        public bool WordBreak(string s, IList<string> wordDict)
        {
            Node root = BuildTrie(wordDict);
            var set = new HashSet<int>();
            return Search(root, 0, s.Length, s, set);
        }

        public bool Search(Node root,int index, int size, string searchWord, HashSet<int> set)
        {
            var NextIndexes=new Stack<int>();
            bool CanBeSegmented = false;
            DFS(root, index, size, searchWord, NextIndexes, ref CanBeSegmented);

            if(CanBeSegmented) return true;

            while (NextIndexes.TryPop(out int i))
            {
                if (!set.Contains(i))
                {
                    set.Add(i);
                    if (Search(root, i, size, searchWord, set))
                        return true;
                }
            }
            return false;
        }

        public void DFS(Node node, int index, int size, string word, Stack<int> NextIndexes, ref bool CanBeSegmented)
        {
            if (index == size)
                return;

            char ch = word[index];

            if (node.children[ch-'a'] == null)
                return;

            node = node.children[ch-'a'];
            if (!string.IsNullOrEmpty(node.word))
            {
                NextIndexes.Push(index+1);
                if (index==size-1)
                {
                    CanBeSegmented = true;
                    return;
                }
            }

            DFS(node, index + 1, size, word, NextIndexes, ref CanBeSegmented);
        }

        public Node BuildTrie(IList<string> dictionary)
        {
            Node root = new Node();
            foreach (var word in dictionary)
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
            return root;
        }

        public class Node
        {
            public Node[] children = new Node[26];
            public string? word;
        }
    }
}

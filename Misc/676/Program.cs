
using System.Collections.Generic;
using System.Text;

namespace _676_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MagicDictionary obj = new MagicDictionary();
            obj.BuildDict(["hello", "hallo", "leetcode"]);
            Console.WriteLine(obj.Search("hello"));
            Console.ReadLine();
        }
    }

    public class MagicDictionary
    {
        Node root;

        public MagicDictionary()
        {
            root = new Node();
        }

        public void BuildDict(string[] dictionary)
        {
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
        }

        public bool Search(string searchWord)
        {
            string FoundedWord = "";
            DFS(root, searchWord, 0, searchWord.Length, ref FoundedWord, false, searchWord);
            if (!string.IsNullOrEmpty(FoundedWord)) return true;

            var word = new StringBuilder(searchWord);
            for (int i = 0; i < searchWord.Length; i++)
            {
                char ch = word[i];
                word[i] = '#';
                string cur = word.ToString();
                DFS(root, cur, 0, cur.Length, ref FoundedWord, false, searchWord);
                if (!string.IsNullOrEmpty(FoundedWord)) return true;
                word[i] = ch;
            }
            return false;
        }

        public void DFS(Node node, string word, int index, int size, ref string foundedWord, bool mismatched, string actualWord)
        {

            if (index == size)
            {
                if (node.word != null && mismatched == true && node.word.Length == actualWord.Length
                     && node.word != actualWord)
                {
                    foundedWord = node.word;
                }
                return;
            }

            char ch = word[index];
            if (ch == '#' || node.children[ch - 'a'] == null)
            {
                if (mismatched == true) return;
                mismatched = true;
                for (int i = 0; i < 26; i++)
                {
                    if (node.children[i] != null)
                    {
                        Node NewNode = node.children[i];
                        DFS(NewNode, word, index + 1, size, ref foundedWord, mismatched, actualWord);
                        if (!string.IsNullOrEmpty(foundedWord)) return;
                    }
                }
                return;
            }


            node = node.children[ch - 'a'];
            DFS(node, word, index + 1, size, ref foundedWord, mismatched, actualWord);
        }

        public class Node
        {
            public Node[] children = new Node[26];
            public string? word;
        }
    }
}
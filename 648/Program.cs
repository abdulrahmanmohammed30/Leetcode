using static _648.Solution;
using System.Text;
using System.Linq;

namespace _648
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution()
                .ReplaceWords(["cat", "bat", "rat"], "the cattle s was rattled by the battery"));
        }
    }
    public class Solution
    {
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            var root = BuildTrie(dictionary);

            var words = sentence.Split(" ");
            var res = new List<string>();
            foreach (var word in words)
            {
                DFS(root, word, 0, res, word.Length);
            }
            return string.Join(" ", res);
        }

        public void DFS(Node node, string word, int index, List<string> res, int size)
        {

            if (index == size)
            {
                res.Add(word);
                return;
            }

            char ch = word[index];
            if (node.children[ch - 'a'] == null)
            {
                res.Add(word);
                return;
            }


            node = node.children[ch - 'a'];
            if (node.word != null)
            {
                res.Add(node.word);
                return;
            }

           DFS(node, word, index+1, res);
        }

        public Node BuildTrie(IList<string> words)
        {
            Node root = new Node();
            foreach (var word in words)
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

using System.ComponentModel.Design.Serialization;

namespace _2707
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MinExtraChar("octncmdbgnxapjoqlofuzypthlytkmchayflwky"

, ["m", "its", "imaby", "pa", "ijmnvj", "k", "mhka", "n", "y", "nc", "wq", "p", "mjqqa", "ht", "dfoa", "yqa", "kk", "pixq", "ixsdln", "rh", "dwl", "dbgnxa", "kmpfz", "nhxjm", "wg", "wky", "oct", "og", "uhin", "zxb", "qz", "tpf", "hlrc", "j", "l", "tew", "xbn", "a", "uzypt", "uvln", "mchay", "onnbi", "hlytk", "pjoqlo", "dxsjr", "u", "uj"]

));
        }
    }
    public class Solution
    {
        public int MinExtraChar(string s, string[] dictionary)
        {
            Node root = BuildTrie(dictionary);

            var set = new Dictionary<int, int>();
            return Determiner(root, s, 0, s.Length, set);
        }

        public int Determiner(Node root, string word, int index, int size, Dictionary<int, int> set)
        {
            if (index == size) return 0;
            if (set.ContainsKey(index)) return set[index];

            int skipsCounter = 0;
            while (index < size && root.children[word[index] - 'a'] == null)
            {
                index++;
                skipsCounter++;
            }
            if (index == size) return skipsCounter;


            var StartIndexes = new List<int>();
            GetSkips(root, word, index, size, StartIndexes);

            int minSkips = size - index;
            foreach (var i in StartIndexes)
                minSkips = Determiner(root, word, i, size, set);

            minSkips=skipsCounter + Math.Min(minSkips,  1 + Determiner(root, word, index + 1, size, set));
            set[index]=minSkips;

            return minSkips;
        }

        public void GetSkips(Node node, string word, int index, int size, List<int> StartIndexes)
        {

            if (!string.IsNullOrEmpty(node.word))
                StartIndexes.Add(index);

            if (index == size || node.children[word[index] - 'a'] == null) return;

            GetSkips(node.children[word[index] - 'a'], word, index + 1, size, StartIndexes);
        }

        public Node BuildTrie(string[] words)
        {
            Node root = new Node();
            foreach (var word in words)
            {
                Node node = root;
                foreach (var ch in word)
                {
                    if (node.children[ch - 'a'] == null)
                        node.children[ch - 'a'] = new Node();
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

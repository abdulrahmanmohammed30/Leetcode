using System.Diagnostics.Tracing;

namespace _212
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

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var res=new HashSet<string>();
            var root = BuildTrie(words);

            int mr = board.Length;
            int mc = board[0].Length;

            for (int r = 0; r < mr; r++)
            {
                for (int c = 0; c < mc; c++)
                {
                    DFS(board, r, c, root, res);
                }
            }

            return res.ToList();
        }

        void DFS(char[][] board, int r, int c,Node node, HashSet<string> res)
        {
            
            char ch = board[r][c];
            if (ch == '#' || node.children[ch - 'a'] == null)
                return;

            node = node.children[ch - 'a'];
            if (node.word != null)
                res.Add(node.word);


            board[r][c] = '#';  
            int[] dirr = { -1, 1, 0, 0 };
            int[] dirc = { 0, 0, -1, 1 };


            for (int i=0;i<4;i++)
            {
                int nr = r+dirr[i];
                int nc = c + dirc[i];


                if (nr >= 0 && nr < board.Length && nc >= 0 && nc < board[0].Length)
                {
                    DFS(board, nr, nc, node, res);
                }
            }
            board[r][c] = ch; 
        }

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

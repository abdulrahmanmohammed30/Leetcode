public class Solution
{
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        var trie = new Trie();
        foreach (var word in words)
            trie.Insert(word);

        var result = new List<string>();
        foreach (var word in words)
            if (trie.CanBeComposedOfTwoOrMoreWords(word)) result.Add(word);

        return result;
    }

    public class Trie
    {
        private class Node
        {
            public Node[] Children = new Node[26];
            public bool IsEndOfWord = false;
        }

        private Node root = new Node();

        public void Insert(string word)
        {
            var currentNode = root;
            foreach (var character in word)
            {
                int index = character - 'a';
                if (currentNode.Children[index] == null)
                {
                    currentNode.Children[index] = new Node();
                }
                currentNode = currentNode.Children[index];
            }
            currentNode.IsEndOfWord = true;
        }

        public bool CanBeComposedOfTwoOrMoreWords(string str)
        {
            var memo = new Dictionary<string, bool>();
            return CanBeComposedHelper(root, str, 0, memo);
        }

        private bool CanBeComposedHelper(Node node, string remainingStr, int count, Dictionary<string, bool> memo)
        {
            if (memo.ContainsKey(remainingStr)) return memo[remainingStr];

            if (remainingStr.Length == 0)
            {
                return count >= 2;
            }

            var currentNode = node;
            for (int i = 0; i < remainingStr.Length; i++)
            {
                char character = remainingStr[i];
                int charIndex = character - 'a';

                if (currentNode.Children[charIndex] == null)
                {
                    memo[remainingStr] = false;
                    return false;
                }

                currentNode = currentNode.Children[charIndex];

                if (currentNode.IsEndOfWord)
                {
                    string nextSubstring = remainingStr.Substring(i + 1);
                    if (CanBeComposedHelper(root, nextSubstring, count + 1, memo))
                    {
                        memo[remainingStr] = true;
                        return true;
                    }
                }
            }

            memo[remainingStr] = false;
            return false;
        }
    }
}

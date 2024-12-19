public class Solution
{

    public int MinCut(string s)
    {
        int n = s.Length;

        var db = new int?[n];
        return Solver(0);
        bool IsPalindrome(int start, int end)
        {
            if (start >= end)
                return true;

            if (s[start] != s[end])
                return false;

            return IsPalindrome(start + 1, end - 1);
        }

        int Solver(int start)
        {
            if (start >= n || IsPalindrome(start, n - 1))
                return 0;

            if (db[start].HasValue)
                return db[start]!.Value;

            int count = int.MaxValue;

            for (int end = start; end < n - 1; end++)
            {
                if (IsPalindrome(start, end))
                {
                    count = Math.Min(count, 1 + Solver(end + 1));
                }
            }
            db[start] = count;
            return count;
        }

    }
}

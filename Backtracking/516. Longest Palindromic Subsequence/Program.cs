public class Solution
{
    public int LongestPalindromeSubseq(string s)
    {
        int n = s.Length;

        var m = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                m[i, j] = -1;


       return Solver(0, n - 1);

        int Solver(int l, int r)
        {

            if (l > r) return 0;
            if (l == r) return 1; 


            if (m[l, r] != -1)
                return m[l, r];

            if (s[l] == s[r]) 
                  m[l, r] = 2 + Solver(l + 1, r - 1);
            else
                m[l, r] = Math.Max(Solver(l + 1, r), Solver(l, r - 1));

            return m[l, r];
        }

    }
}

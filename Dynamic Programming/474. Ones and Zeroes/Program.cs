public class Solution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int sz = strs.Length;
        var zeros = new int[sz];
        var ones = new int[sz];

        for (int i = 0; i < sz; i++)
        {
            zeros[i] = strs[i].Count(x => x == '0');
            ones[i] = strs[i].Count(x => x == '1');
        }

        var cache = new int[sz, m + 1, n + 1];
        for (int i = 0; i < sz; i++)
            for (int j = 0; j <= m; j++)
                for (int k = 0; k <= n; k++)
                    cache[i, j, k] = -1;

        return Solver(0, m, n);

        int Solver(int idx, int m, int n)
        {
            if (idx == sz || (m == 0 && n == 0)) return 0;

            if (cache[idx, m, n] != -1) return cache[idx, m, n];

            int leave = Solver(idx + 1, m, n);
            int pick = 0;

            if (m - zeros[idx] >= 0 && n - ones[idx] >= 0)
            {
                pick = 1 + Solver(idx + 1, m - zeros[idx], n - ones[idx]);
            }

            return cache[idx, m, n] = Math.Max(pick, leave);
        }
    }
}

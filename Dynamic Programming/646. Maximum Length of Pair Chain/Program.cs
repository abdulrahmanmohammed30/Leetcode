public class Solution
{
    public int FindLongestChain(int[][] pairs)
    {
        int n = pairs.GetLength(0);

        var visited = new bool[n];
        var dp = new int[n];
        Array.Fill(dp, -1);

        int res = 0;
        for (int i = 0; i < n; i++)
            res = Math.Max(res, 1 + Solver(i));
        return res;
        int Solver(int idx)
        {
            if (dp[idx] != -1) return dp[idx];
            int max = 0;
            for (int nextIdx = 0; nextIdx < n; nextIdx++)
            {
                if (!visited[nextIdx] && pairs[nextIdx][0] > pairs[idx][1])
                {
                    visited[nextIdx] = true;
                    max = Math.Max(max, 1 + Solver(nextIdx));
                    visited[nextIdx] = false;
                }
            }

            dp[idx] = max;
            return max;
        }
    }

}


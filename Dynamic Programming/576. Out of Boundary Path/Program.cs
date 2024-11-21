public class Solution
{
    private const int MOD = 1000000007;

    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {

        int[,,] dp = new int[m, n, maxMove + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int d = 0; d < maxMove + 1; d++)
                    dp[i, j, d] = -1;
            }
        }

        return Solver(startRow, startColumn, maxMove);
        int Solver(int i, int j, int moves)
        {
            if (moves >= 0 && (i < 0 || j < 0 || i == m || j == n)) return 1;
            if (moves == 0) return 0;
            if (dp[i, j, moves] != -1) return dp[i, j, moves];

            int count = 0;
            count = (int)(count + Solver(i - 1, j, moves - 1)) % MOD;
            count = (int)(count + Solver(i + 1, j, moves - 1)) % MOD;
            count = (int)(count + Solver(i, j + 1, moves - 1)) % MOD;
            count = (int)(count + Solver(i, j - 1, moves - 1)) % MOD;
            dp[i, j, moves] = count;
            return dp[i, j, moves];
        }
    }
}
/// 11:00 
// 11:30 ends done 
// ended 11:41 pm 
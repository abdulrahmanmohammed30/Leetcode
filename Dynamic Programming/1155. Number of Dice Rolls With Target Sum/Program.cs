public class Solution
{
    public int NumRollsToTarget(int n, int k, int target)
    {

        var dp = new int[target + 1, n + 1];
        for (int i = 0; i < target + 1; i++)
            for (int j = 0; j < n + 1; j++)
                dp[i, j] = -1;

        return Solver(target, n);
        int Solver(int r, int n)
        {
            if (r == 0 && n == 0) return 1;
            if (n == 0) return 0;
            if (dp[r, n] != -1) return dp[r, n];

            int count = 0;
            for (int i = 1; i <= k; i++)
            {
                if (r >= i) count = (int)((count + (int)(Solver(r - i, n - 1) % (Math.Pow(10, 9) + 7))) % (Math.Pow(10, 9) + 7));

            }
            dp[r, n] = count;
            return count;
        }
    }
}

public class Solution
{
    public int MinFallingPathSum(int[][] matrix)
    {

        int m = matrix.Length;
        int n = matrix[0].Length;

        int[,] dp = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = int.MaxValue;
            }
        }

        int result = int.MaxValue;
        for (int col = 0; col < n; col++)
        {
            result = Math.Min(result, Solver(0, col));
        }
        return result;
        int Solver(int i, int j)
        {
            if (j < 0 || j >= n) return int.MaxValue;
            if (i == m - 1) return matrix[i][j];
            if (dp[i, j] != int.MaxValue) return dp[i, j];

            int cost = Math.Min(Solver(i + 1, j - 1), Math.Min(Solver(i + 1, j), Solver(i + 1, j + 1)));
            dp[i, j] = matrix[i][j] + cost;
            return dp[i, j];
        }
    }
}
// 10:22 start thinking max 30 mintes ends at 11:00 
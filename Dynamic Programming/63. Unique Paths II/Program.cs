public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {

        int m = obstacleGrid.Length; // Number of rows
        int n = obstacleGrid[0].Length; // Number of columns

        int[,] dp = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = -1;
            }
        }

        return Solver(0, 0);
        int Solver(int i, int j)
        {
            if (i == m || j == n || obstacleGrid[i][j] == 1) return 0;
            if (i == m - 1 && j == n - 1) return 1;
            if (dp[i, j] != -1) return dp[i, j];
            dp[i, j] = Solver(i, j + 1) + Solver(i + 1, j);
            return dp[i, j];
        }
    }
}

// Max time: one hour, ends at 9:31 
// Max time for writing code: 20 Minutes 
// go back to the fixed list of steps to solve a problem from tracing the test cases, etc 
// 9:43 pm ends coding at 9:53 pm 
// -> right 
// --> bottom 

public class Solution
{
    private readonly int[][] directions = new int[][]
    {
        new int[] { 2, 1 }, new int[] { 2, -1 },
        new int[] { -2, 1 }, new int[] { -2, -1 },
        new int[] { 1, 2 }, new int[] { -1, 2 },
        new int[] { 1, -2 }, new int[] { -1, -2 }
    };

    public int KnightDialer(int k)
    {
        int rows = 4, cols = 3;

        int[,,] dp = new int[rows, cols, k + 1];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int m = 0; m <= k; m++)
                {
                    dp[i, j, m] = -1;
                }
            }
        }

        bool IsInsideBoard(int x, int y) => x >= 0 && y >= 0 && x < rows &&
            y < cols && !(x == rows - 1 && y == 0) && !(x == rows - 1 && y == cols - 1);

        int res = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                res = (res + Solver(i, j, k - 1)) % 1000_000_007;
            }
        }
        return res;

        int Solver(int x, int y, int remainingMoves)
        {
            if (!IsInsideBoard(x, y)) return 0;

            if (remainingMoves == 0) return 1;

            if (dp[x, y, remainingMoves] != -1) return dp[x, y, remainingMoves];

            int count = 0;
            foreach (var move in directions)
            {
                int newX = x + move[0];
                int newY = y + move[1];
                count = (count + Solver(newX, newY, remainingMoves - 1)) % 1000_000_007;
            }

            dp[x, y, remainingMoves] = count;
            return count;
        }
    }
}
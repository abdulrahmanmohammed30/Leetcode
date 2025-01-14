public class Solution
{
    private readonly int[][] directions = new int[][]
    {
        new int[] { 2, 1 }, new int[] { 2, -1 },
        new int[] { -2, 1 }, new int[] { -2, -1 },
        new int[] { 1, 2 }, new int[] { -1, 2 },
        new int[] { 1, -2 }, new int[] { -1, -2 }
    };

    public double KnightProbability(int n, int k, int row, int column)
    {
        double[,,] dp = new double[n, n, k + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int m = 0; m <= k; m++)
                {
                    dp[i, j, m] = -1.0;
                }
            }
        }

        bool IsInsideBoard(int x, int y) => x >= 0 && y >= 0 && x < n && y < n;

        double Solver(int x, int y, int remainingMoves)
        {
            // Out of board
            if (!IsInsideBoard(x, y)) return 0;

            // No moves left, check if still on board
            if (remainingMoves == 0) return 1;

            if (dp[x, y, remainingMoves] != -1.0) return dp[x, y, remainingMoves];

            double probability = 0;
            foreach (var move in directions)
            {
                int newX = x + move[0];
                int newY = y + move[1];
                probability += Solver(newX, newY, remainingMoves - 1) / 8.0;
            }

            dp[x, y, remainingMoves] = probability;
            return probability;
        }

        return Solver(row, column, k);
    }
}

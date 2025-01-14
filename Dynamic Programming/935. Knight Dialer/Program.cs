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



// class Solution
// {
//     static int MOD = 1000_000_007;

//     static int[][] neighbors = new int[][]
//     {
//         new int[] { 4, 6 }, // Neighbors of 0
//         new int[] { 6, 8 }, // Neighbors of 1
//         new int[] { 7, 9 }, // Neighbors of 2
//         new int[] { 4, 8 }, // Neighbors of 3
//         new int[] { 0, 3, 9 }, // Neighbors of 4
//         new int[] {},       // No neighbors for 5
//         new int[] { 0, 1, 7 }, // Neighbors of 6
//         new int[] { 2, 6 }, // Neighbors of 7
//         new int[] { 1, 3 }, // Neighbors of 8
//         new int[] { 2, 4 }  // Neighbors of 9
//     };

//     public int KnightDialer(int n)
//     {
//         int[,] dp = new int[10, n + 1];
//         for (int i = 0; i < 10; i++)
//             for (int j = 0; j <= n; j++)
//                     dp[i, j] = -1;

//         int res = 0;
//         for (int i = 0; i < neighbors.Length; i++)
//                 res = (res + Solver(i, n - 1)) % MOD;

//         return res;

//         int Solver(int d, int n)
//         {
//             if (n == 0) return 1;

//             if (dp[d, n] != -1) return dp[d, n];

//             int count = 0;

//             foreach (int neighbor in neighbors[d])
//                 count = (count + Solver(neighbor, n - 1)) % MOD;

//             dp[d,n] = count;
//             return count;
//         }
//     }
// }


// class Solution
// {
//     static int MOD = 1000_000_007;
//     public int KnightDialer(int n)
//     {
//         if (n == 1) return 10;

//         int a = 4, b = 2, c = 2, d = 1;

//         foreach (var i in Enumerable.Range(1, n - 1))
//         {
//             int ta = a, tb = b, tc = c, td = d;
//             a = (2 * ((tb + tc) % MOD)) % MOD;
//             b = ta;
//             c = (ta + ((2 * td) % MOD)) % MOD;
//             d = tc;
//         }
//         return (((((a + b) % MOD) + c) % MOD) + d) % MOD;
//     }
// }
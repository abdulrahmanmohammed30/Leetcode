public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        Array.Sort(coins, (x, y) => y.CompareTo(x));

        int n = coins.Length;
        int[,] cache = new int[n, amount + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= amount; j++)
            {
                cache[i, j] = -1;
            }
        }

        int res = Solver(0, amount);
        return res > 10000 ? -1 : res;

        int Solver(int idx, int remaining)
        {
            if (remaining == 0)
            {
                return 0;
            }

            if (idx >= n || remaining < 0)
            {
                return 50000;
            }

            if (cache[idx, remaining] != -1)
            {
                return cache[idx, remaining];
            }

            int option1 = 1 + Solver(idx, remaining - coins[idx]);
            int option2 = 1 + Solver(idx + 1, remaining - coins[idx]);
            int option3 = Solver(idx + 1, remaining);

            int result = Math.Min(option1, Math.Min(option2, option3));
            cache[idx, remaining] = result;

            return result;
        }
    }
}
public class Solution
{
    public int Change(int amount, int[] coins)
    {
        Array.Sort(coins);

        int n = coins.Length;
        var m = new int[amount + 1, n];
        for (int i = 0; i <= amount; i++)
            for (int j = 0; j < n; j++)
                m[i, j] = -1;

        return Solver(amount, coins.Length - 1);
        int Solver(int remaining, int index)
        {
            if (remaining == 0) return 1;
            if (index < 0 || remaining < 0) return 0;
            if (m[remaining, index] != -1) return m[remaining, index];

            int sum = 0;
            for (int i = index; i >= 0; i--)
            {
                if (remaining - coins[i] >= 0) sum += Solver(remaining - coins[i], i);
            }

            m[remaining, index] = sum;
            return m[remaining, index];
        }
    }
}
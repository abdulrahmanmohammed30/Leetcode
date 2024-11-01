
public class Solution
{
    public int MaxProfit(int[] prices)
    {

        int n = prices.Length;
        var cache = new int[n, 2];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < 2; j++) cache[i, j] = -1;

        return Solver(0, 0);

        int Solver(int i, int holding)
        {
            if (i >= n) return 0;

            if (cache[i, holding] != -1) return cache[i, holding];
            // don't sell or buy. Just Leave. 
            cache[i, holding] = Solver(i + 1, holding);

            // you can buy, coming from a Cooldown state
            if (holding == 0)
                cache[i, holding] = Math.Max(cache[i, holding], -1 * prices[i] + Solver(i + 1, 1));
            // you can sell, holding a transaction
            else
                cache[i, holding] = Math.Max(cache[i, holding], prices[i] + Solver(i + 2, 0));

            return cache[i, holding];
        }
    }
}


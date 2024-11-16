using NUnit.Framework;

class Solution
{
    public int Pearls(int[] quantity, int[] cost)
    {
        var n = quantity.Length;
        var quantityPreSum = new int[n];

        preSum[0] = quantity[0];
        for (int i = 1; i < n; i++)
            preSum[i] = quantity[i - 1] + quantity[i];

        int cost(int start, int end) =>
            return cost[end] * (10 + preSum[end] - preSum[start] + quantity[start]);

        int minCost = int.MaxValue;

        return Solver(0);
        int GetNextGroup(int index)
        {
            for (int end = index; end < n; end++)
                minCost = Math.Min(minCost, cost(index, end) + GetNextGroup(end + 1));
            return minCost;
        }
    }
}



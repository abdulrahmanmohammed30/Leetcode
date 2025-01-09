public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int n = nums.Length;
        int totalSum = nums.Sum();

        if ((totalSum + target) % 2 != 0 || totalSum < Math.Abs(target))
            return 0;

        int fgSum = (nums.Sum() + target) / 2;

        int[,] cache = new int[n, fgSum + 1];

        for (int i = 0; i < n; i++)
            for (int j = 0; j <= fgSum; j++)
                cache[i, j] = -1;

        return Solver(0, 0);
        int Solver(int idx, int sum)
        {
            if (sum > fgSum)
                return 0;

            if (idx == n)
                return sum == fgSum ? 1 : 0;

            if (cache[idx, sum] != -1)
                return cache[idx, sum];

            int includeCurrent = Solver(idx + 1, sum + nums[idx]);

            int excludeCurrent = Solver(idx + 1, sum);
            cache[idx, sum] = includeCurrent + excludeCurrent;

            return cache[idx, sum];
        }
    }
}

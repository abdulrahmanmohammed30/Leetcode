public class Solution
{
    public double LargestSumOfAverages(int[] nums, int k)
    {
        int n = nums.Length;
        double[,] memo = new double[n, k + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= k; j++)
            {
                memo[i, j] = -1.0;
            }
        }
        return MaxScore(0, k);

        double MaxScore(int start, int remainingGroups)
        {
            if (start >= n)
                return 0;

            if (remainingGroups == 0)
                return start >= n ? 0 : double.MinValue;

            if (memo[start, remainingGroups] != -1.0)
                return memo[start, remainingGroups];

            double sum = 0;
            double maxResult = double.MinValue;

            for (int end = start; end < n; end++)
            {
                sum += nums[end];
                double avg = sum / (end - start + 1);
                maxResult = Math.Max(maxResult, avg + MaxScore(end + 1, remainingGroups - 1));
            }

            return memo[start, remainingGroups] = maxResult;
        }
    }
}

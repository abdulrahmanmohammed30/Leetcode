using System;

public class Solution
{
    public int FindNumberOfLIS(int[] nums)
    {
        int n = nums.Length;
        var memo = new (int, int)?[n, n + 1];

        (int, int) Solver(int idx, int prev)
        {
            if (idx == n)
                return (0, 1);

            if (memo[idx, prev] != null)
                return memo[idx, prev].Value;

            var leave = Solver(idx + 1, prev);

            (int, int) pick = (0, 0);
            if (prev == n || nums[idx] > nums[prev])
            {
                var result = Solver(idx + 1, idx);
                pick = (1 + result.Item1, result.Item2);
            }

            int maxLength = Math.Max(leave.Item1, pick.Item1);
            int count = 0;

            if (leave.Item1 == maxLength)
                count += leave.Item2;

            if (pick.Item1 == maxLength)
                count += pick.Item2;

            memo[idx, prev] = (maxLength, count);
            return memo[idx, prev].Value;
        }

        var result = Solver(0, n);
        return result.Item2;
    }
}

public class Solution
{
    public int Jump(int[] nums)
    {
        int n = nums.Length;
        var dp = new int[n]; 
        Array.Fill(dp, -1);

        return Solver(0);
        int Solver(int i)
        {
            if (i == n - 1) return 0;
            if (nums[i] == 0) return 100000;
            
            if (dp[i] != -1) return dp[i];

            int count = int.MaxValue;
            int j = i + nums[i] < n ? nums[i] : n - (i + 1);

            while (j > 0)
            {
                count = Math.Min(count, 1 + Solver(i + j));
                j--;
            }

            dp[i] = count;
            return count;
        }
    }
}
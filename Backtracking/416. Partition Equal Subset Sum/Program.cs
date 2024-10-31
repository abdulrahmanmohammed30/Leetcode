using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public bool CanPartition(int[] nums)
    {
        if (nums.Sum() % 2 != 0) return false;

        int n = nums.Length;
        int target = nums.Sum() / 2;
        var cache = new HashSet<int>();

        return Solver(0, 0);
        bool Solver(int i, int sum)
        {
            if (sum == target) return true;

            if (i == n) return false;

            if (cache.Contains(sum)) return false;
            if (Solver(i + 1, sum)) return true;

            if (sum + nums[i] <= target && (Solver(i + 1, sum + nums[i]))) return true;

            cache.Add(sum);
            return false;
        }
    }
}


// Use a 2-d instead of the dictioanry
public class OptimizedSolution
{
    // Optimized Recursive Solution with Memoization
    public bool CanPartition(int[] nums)
    {
        int totalSum = nums.Sum();
        if (totalSum % 2 != 0) return false;

        int target = totalSum / 2;
        int n = nums.Length;

        // Use bool?[,] instead of Dictionary for better performance
        bool?[,] dp = new bool?[n, target + 1];

        return Solver(0, target);

        bool Solver(int index, int remainingTarget)
        {
            if (remainingTarget == 0) return true;
            if (index >= n || remainingTarget < 0) return false;

            if (dp[index, remainingTarget].HasValue)
                return dp[index, remainingTarget].Value;


            if (Solver(index + 1, remainingTarget - nums[index]))
            {
                dp[index, remainingTarget] = true;
                return true;
            }

            dp[index, remainingTarget] = Solver(index + 1, remainingTarget);
            return (bool)dp[index, remainingTarget];
        }
    }
}


// optimizign usage of datatype
public class MoreOptimizedSolution
{
    public bool CanPartition(int[] nums)
    {
        checked
        {
            short totalSum = 0;
            foreach (int num in nums)
            {
                totalSum += (short)num;
            }

            if (totalSum % 2 != 0) return false;

            short target = (short)(totalSum / 2);
            short n = (short)nums.Length;

            short[] numsShort = new short[n];
            for (int i = 0; i < n; i++)
            {
                numsShort[i] = (short)nums[i];
            }

            bool?[,] dp = new bool?[n, target + 1];
            return Solver(0, target);

            bool Solver(short index, short remainingTarget)
            {

                if (remainingTarget == 0) return true;
                if (index >= n || remainingTarget < 0) return false;


                if (dp[index, remainingTarget].HasValue)
                    return dp[index, remainingTarget].Value;


                bool include = false;
                short newTarget = (short)(remainingTarget - numsShort[index]);
                if (newTarget >= 0)
                {
                    include = Solver((short)(index + 1), newTarget);
                }

                if (include)
                {
                    dp[index, remainingTarget] = true;
                    return true;
                }


                dp[index, remainingTarget] = Solver((short)(index + 1), remainingTarget);
                return dp[index, remainingTarget].Value;
            }
        }
    }
}
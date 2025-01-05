public class Solution
{
    public int GetUniqueNumbersCount(int[] arr)
    {
        int total = 1;
        int n = arr.Length;

        for (int i = 1; i < n; i++)
            if (arr[i] != arr[i - 1]) total++;
        return total;
    }


    public int DeleteAndEarn(int[] arr)
    {
        Array.Sort(arr);
        int n = GetUniqueNumbersCount(arr);

        var nums = new int[n];
        var numsFrequency = new int[n];

        int c = -1;
        nums[++c] = arr[0];
        numsFrequency[c] = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i - 1])
            {
                nums[++c] = arr[i];
                numsFrequency[c] = 1;
            }
            else
                numsFrequency[c]++;
        }

        int[] dp = new int[n];
        Array.Fill(dp, -1);

        return Solver(0);

        int Solver(int idx)
        {
            if (idx >= n)
                return 0;

            if (dp[idx] != -1) return dp[idx];
            int max = 0;

            //int pick = 0;
            // idx + 1 cannot be less than idx 
            // idx + 1 cannot equal idx 
            // only possible option is, there is not next or 
            // next is equal to nums[idx] + 1 or next is greater than nums[idx] + 1
            if (idx == n - 1 || nums[idx + 1] > nums[idx] + 1)
            {
                max = nums[idx] * numsFrequency[idx] + Solver(idx + 1);
            }
            else
            {
                // pick, skip the next element 
                max = nums[idx] * numsFrequency[idx] + Solver(idx + 2);

                // leave 
                max = Math.Max(max, Solver(idx + 1));
            }

            dp[idx] = max;
            return max;
        }
    }
}


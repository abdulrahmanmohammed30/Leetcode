// public class Solution {
//     public int CombinationSum4(int[] nums, int target) {

//     }
// }

public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        Array.Sort(nums);

        int n = nums.Length;
        var m = new int[target + 1];
        Array.Fill(m, -1);

        return Solver(target);
        int Solver(int remaining)
        {
            if (remaining == 0) return 1;
            if (remaining < 0) return 0;
            if (m[remaining] != -1) return m[remaining];

            int sum = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (remaining - nums[i] >= 0) sum += Solver(remaining - nums[i]);
            }

            m[remaining] = sum;
            return m[remaining];
        }
    }
}
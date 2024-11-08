public class Solution
{
    public int LengthOfLIS(int[] nums)
    {

        int n = nums.Count();
        var m = new int[n];

        for (int i = 0; i < n; i++) m[i] = -1;


        int Solver(int idx)
        {
            if (idx == nums.Count()) return 0;
            if (m[idx] != -1) return m[idx];

            int mns = 0;
            for (int next = idx + 1; next < n; next++)
            {
                if (nums[next] > nums[idx])
                {
                    mns = Math.Max(mns, Solver(next));
                }
            }

            m[idx] = 1 + mns;
            return m[idx];
        }

        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res = Math.Max(res, Solver(i));
        }

        return res;
    }
}

using System.ComponentModel.DataAnnotations;

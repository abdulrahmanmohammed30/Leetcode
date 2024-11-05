using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using Internal;

// rewrite 
// tracing some test cases is very crucial to identity repeated test cases 
// and not just on a small set of cases without covering all the common test cases 
// think about all the possible cases or your solution will be a toy solution not practice and you will be rejected 
// from any interview  
// time for thinking about the problem 
// time for thinking about test cases and tracing 
// never waste time on coding - coding should be done last 


public class Solution
{
    public int MinimumMountainRemovals(int[] nums)
    {

        int n = nums.Count();
        var m1 = new int[n];
        var m2 = new int[n];

        for (int i = 0; i < n; i++)
        {
            m1[i] = -1;
            m2[i] = -1;
        }

        int Solver1(int idx)
        {
            if (idx == nums.Count()) return 0;
            if (m1[idx] != -1) return m1[idx];

            int mns = 0;
            for (int pre = 0; pre < idx; pre++)
                if (nums[idx] > nums[pre])
                    mns = Math.Max(mns, Solver1(pre));
            m1[idx] = 1 + mns;
            return m1[idx];
        };

        int Solver2
                     (int idx)
        {
            if (idx == nums.Count()) return 0;
            if (m2[idx] != -1) return m2[idx];

            int mns = 0;
            for (int next = idx + 1; next < n; next++)
                if (nums[next] < nums[idx])
                    mns = Math.Max(mns, Solver2(next));
            m2[idx] = 1 + mns;
            return m2[idx];
        };

        int res = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            Solver1(i);
            Solver2(i);

            if (m1[i] > 1 && m2[i] > 1)
                res = Math.Min(res, n - (m1[i] + m2[i] - 1));
        }
        return res;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

// TLE 
// public class Solution
// {
//     public int MinimizeTheDifference(int[][] mat, int target)
//     {
//         int n = mat.Length;
//         int m = mat[1].Length;
//         return Solver(0, 0);

//         int Solver(int r, int sum)
//         {
//             if (r >= n)
//                 return int.Abs(target, sum);

//             int min = int.MaxValue;
//             for (int c = 0; c < m; c++)
//             {
//                 min = Math.Min(min, Solver(r + 1, sum + mat[r][c]));
//             }
//             return min;
//         }
//     }
// }

public class Solution
{
    public int MinimizeTheDifference(int[][] mat, int target)
    {
        var sums = new HashSet<int>() { 0 };
        foreach (var row in mat)
        {
            var newSums = new HashSet<int>();
            foreach (var sum in sums)
            {
                foreach (var num in row)
                {
                    newSums.Add(sum + num);
                }
            }
            sums = newSums;
        }
        return sums.Min(s => Math.Abs(s - target));
    }
}
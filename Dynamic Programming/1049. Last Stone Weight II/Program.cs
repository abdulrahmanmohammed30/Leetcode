public class Solution
{
    public int LastStoneWeightII(int[] stones)
    {
        int n = stones.Length;
        int total = stones.Sum();
        int halfTotal = total / 2;

        var db = new int[n, halfTotal + 1];
        for (int i = 0; i < n; i++)
            for (int j = 0; j <= halfTotal; j++)
                db[i, j] = -1;

        return Solver(0, 0);

        int Solver(int idx, int sum)
        {
            if (sum > halfTotal) return int.MaxValue;
            if (idx == n)
            {
                int sum2 = total - sum;
                return sum2 - sum;
            }
            if (db[idx, sum] != -1) return db[idx, sum];

            int fg = Solver(idx + 1, sum + stones[idx]);
            int sg = Solver(idx + 1, sum);
            db[idx, sum] = Math.Min(fg, sg);
            return db[idx, sum];
        }
    }
}


// public class Solution
// {
//     public int LastStoneWeightII(int[] stones)
//     {
//         int n = stones.Length;
//         int total = stones.Sum();
//         var db = new int[n, total + 1];
//         for (int i = 0; i < n; i++)
//             for (int j = 0; j < total + 1; j++)
//                 db[i, j] = -1;


//         return Solver(0, 0);
//         int Solver(int idx, int sum)
//         {
//             if (idx == n)
//             {
//                 int sum2 = total - sum;
//                 return Math.Abs(sum - sum2);
//             }
//             if (db[idx, sum] != -1) return db[idx, sum];

//             int fg = Solver(idx + 1, sum + stones[idx]);
//             int sg = Solver(idx + 1, sum);
//             db[idx, sum] = Math.Min(fg, sg);
//             return db[idx, sum];
//         }
//     }
// }

// thinking: 1 2 3
// writing code  1

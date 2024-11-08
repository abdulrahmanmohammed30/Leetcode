
// public class Solution
// {
//     public int IntegerBreak(int n)
//     {

//         var visited = new HashSet<(int, int)>();
//         int res = 0;
//         Solver(0, 1);
//         return res;

//         void Solver(int sum, int product)
//         {

//             if (sum == n)
//             {
//                 res = Math.Max(res, product);
//                 return;
//             }

//             if (visited.Contains((sum, product))) return;


//             visited.Add((sum, product));

//             for (int i = 1; i < n; i++)
//             {
//                 if (i + sum <= n)
//                 {
//                     Solver(i + sum, i * product);
//                 }

//             }
//         }
//     }
// }

// optimized version 
public class Solution
{
    public int IntegerBreak(int n)
    {

        var visited = new HashSet<(int, int)>();
        int res = 0;
        Solver(0, 1);
        return res;

        void Solver(int sum, int product)
        {

            if (sum == n)
            {
                res = Math.Max(res, product);
                return;
            }

            if (visited.Contains((sum, product))) return;


            visited.Add((sum, product));

            for (int i = 1; i < n; i++)
            {
                if (i + sum <= n)
                {
                    Solver(i + sum, i * product);
                }

            }
        }
    }
}
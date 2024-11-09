
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

// Some optimizations  
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

// optimized soluion
public class Solution
{
    public int IntegerBreak(int n)
    {
        if (n == 2) return 1;
        if (n == 3) return 2;
        
        var visited = new int [n + 1];
        int res = 0;
        Solver(n, 1);
        return res;

        void Solver(int sum, int product)
        {
            if (sum < 0) return;
            
            if (sum == 0)
            {
                res = Math.Max(res, product);
                return;
            }
            
            if (visited[sum] >= product) return; 


            visited[sum]=product;

            Solver(sum - 2, product * 2);
            Solver(sum - 3, product * 3);
        }
    }
}



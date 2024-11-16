public class Solution
{
    public int NumSquares(int n)
    {

        var visited = new int [n + 1];
        for(int i=0; i<=n; i++) visited[i]=-1;
        int res = int.MaxValue;
        Solver(0, 0);
        return res;

        void Solver(int sum, int count)
        {   
            if (n - sum == 1){
                 sum=n;
                 count = count + 1;
            }

            if (sum == n)
            {
                res = Math.Min(res, count);
                return;
            }
             
             if (visited[sum] != -1 && visited[sum] <= count) return;
             visited[sum]=count;

            for (int i = (n - sum) / 2; i > 0; i--)
            {
                if (i * i + sum <= n)
                {
                    Solver(i * i + sum, count + 1);
                }

            }
        }
    }
}


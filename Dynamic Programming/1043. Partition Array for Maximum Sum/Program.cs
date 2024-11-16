
public class Solution
{
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        int n = arr.Length;
        int[] m = new int[n];
        Array.Fill(m, -1);

        return Solver(0);
        int Solver(int start)
        {
            if (start == n) return 0;
            if (m[start] != -1) return m[start];

            int max = 0;
            int l = 0;
            while (l < k && start + l < n)
            {
                max = Math.Max(max, arr[start + l]);
                m[start] = Math.Max(m[start], (l + 1) * max + Solver(start + l + 1));
                l++;
            }
            return m[start];
        }
    }
}

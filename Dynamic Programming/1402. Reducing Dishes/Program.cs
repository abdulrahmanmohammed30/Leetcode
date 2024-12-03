public class Solution
{
    public int MaxSatisfaction(int[] satisfaction)
    {
        int n = satisfaction.Length;
        Array.Sort(satisfaction);
        var m = new int[n, n + 1];
        for (int i = 0; i < n; i++)
            for (int j = 0; j <= n; j++)
                m[i, j] = -1;


        return Solver(0, 1);

        int Solver(int idx, int position)
        {
            if (idx == n) return 0;
            if (m[idx, position] != -1) return m[idx, position];

            int leave = Solver(idx + 1, position);
            int pick = satisfaction[idx] * position + Solver(idx + 1, position + 1);

            m[idx, position] = Math.Max(leave, pick);
            return m[idx, position];
        }
    }
}

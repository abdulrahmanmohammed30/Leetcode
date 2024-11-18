public class Solution
{
    public int MinCost(int n, int[] cuts)
    {

        int sz = n + 1;
        var visited = new bool[cuts.Length];
        var m = new Dictionary<(int, int), int>();

        return Solver(0, n);
        int Solver(int start, int end)
        {
            if (end - start <= 1) return 0;

            if (m.ContainsKey((start, end)) == true) return m[(start, end)];
            int min = int.MaxValue;

            for (int i = 0; i < cuts.Length; i++)
            {
                if (cuts[i] - 1 >= start && cuts[i] <= end && !visited[i])
                {
                    visited[i] = true;
                    min = Math.Min(min, end - start + Solver(start, cuts[i]) + Solver(cuts[i], end));
                    visited[i] = false;
                }
            }

            m[(start, end)] = min == int.MaxValue ? 0 : min;
            return m[(start, end)];
        }
    }
}
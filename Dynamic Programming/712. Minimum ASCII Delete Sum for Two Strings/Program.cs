public class Solution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        int n = s1.Length, m = s2.Length;
        var db = new int?[n, m];
        return Solver(0, 0);
        int Solver(int i, int j)
        {
            if (i == n || j == m)
            {
                int i0 = i, j0 = j;
                int count = 0;
                while (i < n)
                    count += s1[i++];
                while (j < m)
                    count += s2[j++];
                return count;
            }

            if (db[i, j].HasValue) return db[i, j]!.Value;

            int min = int.MaxValue;

            if (s1[i] == s2[j])
                min = Solver(i + 1, j + 1);

            min = Math.Min(min, s1[i] + Solver(i + 1, j));
            min = Math.Min(min, s2[j] + Solver(i, j + 1));
            db[i, j] = min;
            return min;
        }
    }
}


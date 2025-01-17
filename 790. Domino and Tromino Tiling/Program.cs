public class Solution
{
    public int NumTilings(int n)
    {
        var d = new int?[n + 1, 4];
        var MODD = 1000000007;

        return Solver(0, true, true);
        int Solver(int i, bool t1, bool t2)
        {
            if (i == n)
                return 1;

            int state = 0;
            if (t1) state |= 1;
            if (t2) state |= 2;

            if (d[i, state].HasValue) return d[i, state]!.Value;
            int count = 0;
            bool t3 = i + 1 < n, t4 = i + 1 < n;

            // put one 2 * 1 vertically 
            if (t1 && t2) count = (count + Solver(i + 1, true, true)) % MODD;

            // put two 2 * 1 horizontally 
            if (t1 && t2 & t3 & t4) count = (count + Solver(i + 1, false, false)) % MODD;

            // put one L 
            if (t1 && t2 && t3) count = (count + Solver(i + 1, false, true)) % MODD;

            // put one L 
            if (t1 && t2 && t4) count = (count + Solver(i + 1, true, false)) % MODD;

            // use L 
            if (t1 && !t2 && t3 && t4) count = (count + Solver(i + 1, false, false)) % MODD;

            // use a vertical 2 * 1 
            if (t1 && !t2 && t3) count = (count + Solver(i + 1, false, true)) % MODD;

            // use an L 
            if (!t1 && t2 && t3 && t4) count = (count + Solver(i + 1, false, false)) % MODD;

            // use a vertical 2 * 1 
            if (!t1 && t2 && t4) count = (count + Solver(i + 1, true, false)) % MODD;

            if (!t1 && !t2) count = (count + Solver(i + 1, true, true)) % MODD;

            d[i, state] = count % MODD;

            return count % MODD;
        }
    }
}


public class Solution
{
    public int NthUglyNumber(int n)
    {
        var set = new SortedSet<int>();
        var m = new HashSet<(int, int)>();

        set.Add(1);
        Solver(1, 1);

        int count = 1;
        foreach (var i in set)
            if (count++ == n) return i;
        return 0;
        void Solver(int cur, int moves)
        {

            if (moves == n || m.Contains((cur, moves))) return;
            m.Add((cur, moves));

            if ((long)cur * 2 <= (long)int.MaxValue)
            {
                Solver(cur * 2, moves + 1);
                set.Add(cur * 2);
            }

            if ((long)cur * 3 <= (long)int.MaxValue)
            {
                Solver(cur * 3, moves + 1);
                set.Add(cur * 3);
            }

            if ((long)cur * 5 <= (long)int.MaxValue)
            {
                Solver(cur * 5, moves + 1);
                set.Add(cur * 5);
            }
        }
    }
}

// 9:11 max 10  done 9:22 9:28 pm  9:32 pm 

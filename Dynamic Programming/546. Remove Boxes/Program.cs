public class Solution
{
    public int RemoveBoxes(int[] boxes)
    {
        int n = boxes.Length;
        var db = new int?[n, n, n];

        return Solver(0, boxes.Length - 1, 0);
        int Solver(int start, int end, int sameColorCount)
        {
            if (start > end)
                return 0;

            if (db[start, end, sameColorCount] != null) return db[start, end, sameColorCount] ?? 0;

            // Need to record the intial values of i and k in order to
            // apply the following optimization
            int start0 = start, sameColorCount0 = sameColorCount;

            // optimization: all boxes of the same color counted continuously
            // from the first box should be grouped together
            while (start + 1 <= end && boxes[start + 1] == boxes[start])
            {
                start++;
                sameColorCount++;
            }
            int res = (sameColorCount + 1) * (sameColorCount + 1) + Solver(start + 1, end, 0);
            for (int m = start + 1; m <= end; m++)
            {
                // a potential optimal solution
                if (boxes[start] == boxes[m])
                {
                    res = Math.Max(res, Solver(start + 1, m - 1, 0) +
                                      Solver(m, end, sameColorCount + 1));
                }
            }
            db[start0, end, sameColorCount0] = res;
            return res;
        }
    }
}
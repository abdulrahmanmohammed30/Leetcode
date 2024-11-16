public class Solution
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {

        int n = books.GetLength(0);
        var m = new int[n];
        for (int i = 0; i < n; i++) m[i] = -1;

        return Solver(0);
        int Solver(int start)
        {
            if (start == n) return 0;
            if (m[start] != -1) return m[start];

            int totalThickness = 0;
            int maxHeight = 0;
            int ans = int.MaxValue;

            for (int end = start; end < n; end++)
            {
                if (totalThickness + books[end][0] > shelfWidth) break;
                totalThickness += books[end][0];
                maxHeight = Math.Max(maxHeight, books[end][1]);
                ans = Math.Min(ans, maxHeight + Solver(end + 1));
            }
            m[start] = ans;
            return ans;
        }
    }
}
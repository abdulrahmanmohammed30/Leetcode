
var disks = new int [,]{ {2, 1, 2 }, { 3, 2, 3 }, { 2, 2, 8 }, { 2, 3, 4 }, { 1, 3, 1 }, { 4, 4, 5 } };
// Convert to list of rows
var sortedRows = Enumerable.Range(0, disks.GetLength(0))
                           .Select(i => new int[] { disks[i, 0], disks[i, 1], disks[i, 2] })
                           .OrderBy(row => row[2])
                           .ToList();

// Convert sorted list back to 2D array
for (int i = 0; i < sortedRows.Count; i++)
{
    disks[i, 0] = sortedRows[i][0];
    disks[i, 1] = sortedRows[i][1];
    disks[i, 2] = sortedRows[i][2];
}

var selectedDisks =  new Solution().DiskStacking(disks);
Console.WriteLine("Stacked Disks (Width, Depth, Height):");

foreach (var disk in selectedDisks)
{
    Console.WriteLine($"({disk[0]}, {disk[1]}, {disk[2]})");
}

class Solution
{
    public List<int[]> DiskStacking(int[,] disks)
    {
        int n = disks.GetLength(0);

        int[] memo = new int[n];
        Array.Fill(memo, -1);

        int[] parent = new int[n];  // Track parent indices for reconstruction
        Array.Fill(parent, -1);

        int maxHeight = 0, startIndex = -1;

        for (int i = 0; i < n; i++)
        {
            int height = disks[i, 2] + Solver(i, disks, memo, parent);
            if (height > maxHeight)
            {
                maxHeight = height;
                startIndex = i;
            }
        }

        List<int[]> maxStack = ReconstructStack(disks, parent, startIndex);

        return maxStack;
    }

    static int Solver(int cur, int[,] disks, int[] memo, int[] parent)
    {
        if (memo[cur] != -1)
            return memo[cur];

        int maxHeight = 0;

        for (int i = cur + 1; i < disks.GetLength(0); i++)
        {
            if (CanStackOnTop(disks, cur, i))
            {
                int height = disks[i, 2] + Solver(i, disks, memo, parent);
                if (height > maxHeight)
                {
                    maxHeight = height;
                    parent[cur] = i;  // Store the index of the next disk in the stack
                }
            }
        }

        memo[cur] = maxHeight;
        return memo[cur];
    }

    static bool CanStackOnTop(int[,] disks, int top, int bottom)
    {
        return disks[top, 0] < disks[bottom, 0] &&
               disks[top, 1] < disks[bottom, 1] &&
               disks[top, 2] < disks[bottom, 2];
    }

    static List<int[]> ReconstructStack(int[,] disks, int[] parent, int startIndex)
    {
        List<int[]> result = new List<int[]>();

        while (startIndex != -1)
        {
            result.Add(new int[] { disks[startIndex, 0], disks[startIndex, 1], disks[startIndex, 2] });
            startIndex = parent[startIndex];
        }

        return result;
    }
}

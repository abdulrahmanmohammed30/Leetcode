public class Solution
{
    public int NumSubmat(int[][] mat)
    {
        int rows = mat.Length;
        int cols = mat[0].Length;

        int Solver(int currentRow, int currentColumn)
        {
            int count = 0;
            int bound = cols;
            for (int i = currentRow; i < rows; i++)
            {
                for (int j = currentColumn; j < bound; j++)
                {
                    if (mat[i][j] == 1) count++;
                    else bound = j;
                }

                if (bound == currentColumn) break;
            }
            return count;
        }

        int count = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                count += Solver(i, j);
    return count;
    }
}
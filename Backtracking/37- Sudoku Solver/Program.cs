namespace _37__Sudoku_Solver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
    class Solution
    {
        public void SolveSudoku(char[][] board)
        {
            var vrows = new HashSet<char>[9];
            var vcols = new HashSet<char>[9];
            var vboxes = new bool[3, 3, 9];

            for (int i = 0; i < 9; i++)
                vrows[i] = new HashSet<char>();

            for (int i = 0; i < 9; i++)
                vcols[i] = new HashSet<char>();

            var cells = new List<(int, int)>(81);

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r][c] == '.')
                        cells.Add((r, c));
                    else
                    {
                        int num = ((int)(board[r][c])) - 49;
                        vrows[r].Add(board[r][c]);
                        vcols[c].Add(board[r][c]);
                        vboxes[r / 3, c / 3, num] = true;
                    }
                }
            }

            int sz = cells.Count;

            bool Solver(int cur)
            {
                if (cur == sz)
                    return true;

                for (int i = 1; i <= 9; i++)
                {
                    (int r, int c) = cells[cur];

                    char ch = (char)(i + 48);
                    if (!vrows[r].Contains(ch) &&
                        !vcols[c].Contains(ch) &&
                        !vboxes[r / 3, c / 3, i - 1])
                    {
                        vrows[r].Add(ch);
                        vcols[c].Add(ch);
                        vboxes[r / 3, c / 3, i - 1] = true;
                        board[r][c] = ch;

                        if (Solver(cur + 1)) return true;

                        // Undo the changes if this path doesn't lead to a solution
                        vrows[r].Remove(ch);
                        vcols[c].Remove(ch); // Corrected: Undo in column validation set
                        vboxes[r / 3, c / 3, i - 1] = false;
                        board[r][c] = '.';
                    }
                }

                return false;
            }

            Solver(0);
        }
    }

}

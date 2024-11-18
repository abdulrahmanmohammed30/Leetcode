using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _51._N_Queens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strArr = @"//war//fight.png".Split("//");
            Console.WriteLine(strArr[1] + " " + strArr.Count() + strArr[2]);
            return;
            var res = new Solution().SolveNQueens(4);
            foreach (var i in res)
            {
                foreach (var j in i)
                    Console.WriteLine(j);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

    public class Solution
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            var solutions = new List<List<(int, int)>>();

            Solver(n, new (int r, int c)[n + 1]);

            var res = new List<IList<string>>();
            foreach (var solution in solutions)
            {
                var curRes = Enumerable.Repeat(new string('.', n), n).ToList();

                for (int row = 1; row <= n; row++)
                {
                    (int r, int c) = solution[row];
                    curRes[r - 1] = new string('.', c - 1) + 'Q' + new string('.', n - c);
                }
                res.Add(curRes);
            }

            return res;
            bool isValid(int row, int col, (int r, int c)[] cur)
            {
                foreach (var (r, c) in cur)
                {
                    if (r == 0 && c == 0) continue;

                    if (row == r)
                        return false;

                    if (col == c)
                        return false;

                    if (Math.Abs(row - r) == Math.Abs(col - c))
                        return false;
                }

                return true;
            }


            void Solver(int row, (int r, int c)[] cur)
            {
                if (row == 0)
                {
                    solutions.Add(new List<(int, int)>(cur));
                    return;
                }


                for (int col = 1; col <= n; col++)
                {
                    if (isValid(row, col, cur))
                    {
                        cur[row] = (row, col);

                        Solver(row - 1, cur);

                        cur[row] = (0, 0);
                    }
                }
            }
        }
    }
}
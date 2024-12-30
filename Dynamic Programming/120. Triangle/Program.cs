public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count();
        int m = triangle[n - 1].Count();

        var cacheArray = new int?[n, m];


        return Solver(0, 0);

        int Solver(int idx, int pos)
        {
            if (idx == n)
            {
                return 0;
            }

            if (cacheArray[idx, pos].HasValue)
            {
                return cacheArray[idx, pos]!.Value;
            }


            int option1 = Solver(idx + 1, pos);
            int option2 = Solver(idx + 1, pos + 1);

            int minValue = Math.Min(option1, option2);
            long sum = (long)minValue + triangle[idx][pos];

            if (sum > int.MaxValue)
            {
                sum = int.MaxValue;
            }

            int result = (int)sum;

            cacheArray[idx, pos] = result;

            return result;
        }
    }
}

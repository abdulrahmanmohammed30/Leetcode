
public class Solution
{
    public int MctFromLeafValues(int[] arr)
    {
        int n = arr.Length;
        (int max, int sum)[,] dp = new (int max, int sum)[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                dp[i, j] = (-1, -1);

        return MinTreeSum(0, n - 1).sum;

        (int max, int sum) MinTreeSum(int l, int r)
        {
            // Some invalid cases 
            // so we handle it by setting the max as 0 and the sum as a large number that will never 
            // be selected 
            if (l > r)
                return (0, 100000);

            // leaf node
            // max is the element itself, sum is zero since leaf node are not counted
            if (l == r) return (arr[l], 0);

            if (dp[l, r] == (-1, -1)) return dp[l, r];
            (int max, int sum) ans = (0, 100000);
            for (int i = l; i < r; i++)
            {
                (int max, int sum) pLeft = MinTreeSum(l, i);
                (int max, int sum) pRight = MinTreeSum(i + 1, r);
                int total = pLeft.sum + pRight.sum + (pLeft.max * pRight.max);

                // If the current split or the current sub-tree has less weight then the  selected sub-tree 
                // to be the answer. Then set the ans to the current sub-tree
                if (total < ans.sum)
                {
                    ans.max = Math.Max(pLeft.max, pRight.max);
                    ans.sum = total;
                }
            }
            dp[l, r] = ans;
            return ans;
        }
    }
}
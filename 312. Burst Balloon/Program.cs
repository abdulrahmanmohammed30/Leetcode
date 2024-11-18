public class Solution
{
    public int MaxCoins(int[] arr)
    {

        int n = arr.Length + 2;
        var nums = new int[n];
        nums[0] = nums[n - 1] = 1;
        Array.Copy(arr, 0, nums, 1, arr.Length);

        var m = new int[n, n];

        return Solver(1, n - 2);
        int Solver(int left, int right)
        {
            if (left > right) return 0;
            if (m[left, right] > 0) return m[left, right];

            int max = int.MinValue;

            for (int i = left; i <= right; i++)
            {
                max = Math.Max(max, nums[left - 1] * nums[i] * nums[right + 1] + Solver(left, i - 1) + Solver(i + 1, right));
            }

            m[left, right] = max;
            return m[left, right];
        }
    }
}
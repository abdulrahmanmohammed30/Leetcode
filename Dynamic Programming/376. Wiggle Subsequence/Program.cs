class Solution
{
    public int WiggleMaxLength(int[] nums)
    {

        int n = nums.Length;
        var m = new Dictionary<(int, int, bool?), int>();

        return Solver(0, n, null);
        int Solver(int index, int prev, bool? status)
        {
            if (index == n)
                return 0;

            if (m.ContainsKey((index, prev, status))) return m[(index, prev, status)];
            int c1 = Solver(index + 1, prev, status);

            int c2 = 0;
            if (prev == n)
                c2 = 1 + Solver(index + 1, index, null);

            int c3 = 0;
            if (prev != n && prev >= 0 && prev < nums.Length && nums[index] != nums[prev] &&
             (!status.HasValue ||
              nums[index] - nums[prev] < 0 && status.Value == true ||
              nums[index] - nums[prev] > 0 && status.Value == false))
                c3 = 1 + Solver(index + 1, index, nums[index] - nums[prev] > 0 ? true : false);
            m[(index, prev, status)] = Math.Max(c1, Math.Max(c2, c3));
            return m[(index, prev, status)];
        }
    }
}

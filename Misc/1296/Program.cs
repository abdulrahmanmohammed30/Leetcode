using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace _1296
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 4, 3, 2, 3, 5, 2, 1 };
            int k = 4;
            Console.WriteLine(new Solution().CanPartitionKSubsets(nums, k));

            Console.ReadLine();
        }
    }
    public class Solution
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            if (nums.Sum() % k != 0 || nums.Length < k) return false;

            var visited = new bool[nums.Length];
            int sum = nums.Sum() / k;
            Array.Sort(nums, (a, b) => b.CompareTo(a));
            if (nums[0] > sum) return false;

            if (try_partition(0, 0, 0))
                return true;
            return false;


            bool try_partition(int partition_index, int cur_index, int cur_sum)
            {
                if (partition_index == k)
                    return true;

                if (cur_sum == sum)
                    return try_partition(partition_index + 1, 0, 0);

                // We collected a lot of numbers 
                // that their sum is less than sum and reached the end of the array 
                if (cur_index == nums.Length)
                    return false;

                if (!visited[cur_index] && cur_sum + nums[cur_index] <= sum)
                {
                    visited[cur_index] = true;

                    if (try_partition(partition_index, cur_index + 1, cur_sum + nums[cur_index]))
                        return true;

                    visited[cur_index] = false;

                }

                if (try_partition(partition_index, cur_index + 1, cur_sum))
                    return true;

                return false;
            }
        }
    }
}

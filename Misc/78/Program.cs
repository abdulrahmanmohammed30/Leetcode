using System.Collections.Generic;
using System.ComponentModel;

namespace _78_
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] nums = new int[] { 1, 2, 3,4 };
           var res= Subsets(nums);
           foreach(var i in res)
            {
                foreach(var j in i)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
       static public IList<IList<int>> Subsets(int[] nums)
        {
            var arr = new List<IList<int>>() { new List<int>() };
            int sz = nums.Length;

            for (int i = 0; i < sz; i++)
            {
                arr.Add(new List<int> { nums[i] });
                GetCurrentElementSets(nums, i + 1, new List<int> { nums[i] });
            }
            return arr;


            void GetCurrentElementSets(int[] nums, int startIndex, List<int> sets)
            {
                if (startIndex == sz)
                    return;

                for (int j = startIndex; j < sz; j++)
                {
                    sets.Add(nums[j]);
                    arr.Add(new List<int>(sets));
                    GetCurrentElementSets(nums, j + 1, sets);
                    sets.Remove(nums[j]);
                }
            }
        }
    }
    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var arr= new List<IList<int>>() { new List<int>()};
            int sz = nums.Length;

            for (int i = 0; i < sz; i++)
            {
                arr.Add(new List<int> {nums[i]});
                GetCurrentElementSets(nums, i+1, new List<int> { nums[i] });
            }
            return arr; 


            void GetCurrentElementSets(int[] nums, int index, List<int>sets) {
                if (index == sz)
                    return;

                for(int j=index;index<sz;j++)
                {
                    sets.Add(nums[j]);
                    arr.Add(new List<int>(sets));
                    GetCurrentElementSets(nums, j + 1, sets);
                    sets.Remove(nums[j]);
                }
            }
        }
    }
}

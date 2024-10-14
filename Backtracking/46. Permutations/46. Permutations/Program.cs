using System.Collections.Generic;
using System.Runtime.Loader;

namespace _46._Permutations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
     }
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var res = new List<IList<int>>();
            int n = nums.Length;

            void Solver(List<int> cur, bool[] visited)
            {
                if (cur.Count == n)
                {
                    res.Add(new List<int>(cur));
                    return;
                }

                for (int i = 0; i < n; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        cur.Add(nums[i]);

                        Solver(cur, visited);

                        cur.RemoveAt(cur.Count - 1);
                        visited[i] = false;
                    }
                }
            }

            Solver(new List<int>(), new bool[n]);
            return res;
        }
    }

}

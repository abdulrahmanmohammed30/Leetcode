using System.Numerics;

namespace _1023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = new Solution().CamelMatch(["FooBarTest"], "FB");
            foreach (var i in res)
                Console.WriteLine(i);
        }
    }


    //    public IList<bool> CamelMatch(string[] queries, string pattern)
    //    {
    //        var res = new bool[queries.Length];

    //        for (int i = 0; i < queries.Length; i++)
    //        {
    //            int p1 = 0, p2 = 0;
    //            string query = queries[i];

    //            while (p1 < query.Length && p2 < pattern.Length)
    //            {
    //                if (query[p1] != pattern[p2])
    //                    p1++;
    //                else p2++;
    //            }

    //            if (p2 < pattern.Length) continue;

    //            while (p1 < query.Length)
    //                if (query[p1] >= 'A' && query[p1] <= 'Z') continue;

    //            res[i] = true;
    //        }
    //        return res;
    //    }

    //}

    public class Solution
    {
        public IList<bool> CamelMatch(string[] queries, string pattern)
        {

            var res = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int p1 = 0, p2 = 0;
                string query = queries[i];
                bool skip = false;

                while (p1 < query.Length && p2 < pattern.Length)
                {
                    if (query[p1] == pattern[p2])
                        p2++;
                    else if (char.IsUpper(query[p1]))
                    {
                        skip = true;
                        break;
                    }
                    p1++;
                }
                if (skip || p2 < pattern.Length) continue;

                skip = false;
                while (p1 < query.Length)
                    if (char.IsUpper(query[p1++]))
                    {
                        skip = true;
                        break;
                    }

                if (skip) continue;

                res[i] = true;
            }
            return res;
        }
    }
}

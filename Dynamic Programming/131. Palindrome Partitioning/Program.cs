// public class Solution
// {
//     public IList<IList<string>> Partition(string s)
//     {

//         int n = s.Count();
//         var d = new Dictionary<int, List<int>>();

//         for (int i = 0; i < n; i++)
//             d[i] = new List<int>() { i };

//         for (int i = 0; i < n; i++)
//         {
//             Solver(i, i + 1);
//             Solver(i - 1, i + 1);
//         }

//         void Solver(int l, int r)
//         {
//             while (l >= 0 && r < n && s[l] == s[r])
//             {
//                 d[l].Add(r);
//                 l--;
//                 r++;
//             }
//         }

//         var res = new List<IList<string>>();
//         var p = new List<string>();


//         foreach (var end in d[0])
//         {
//             p.Add(s.Substring(0, end + 1));
//             FillPartition(end + 1, p);
//             p.RemoveAt(p.Count() - 1);

//         }


//         return res;
//         void FillPartition(int start, List<string> partition)
//         {
//             if (start >= n)
//             {
//                 res.Add(partition.ToList());
//                 return;
//             }

//             var ends = d[start];

//             foreach (var end in ends)
//             {
//                 partition.Add(s.Substring(start, (end - start) + 1));
//                 FillPartition(end + 1, partition);
//                 partition.RemoveAt(partition.Count() - 1);
//             }
//         }
//     }
// }
public class Solution
{
    public IList<IList<string>> Partition(string s)
    {
        int n = s.Length;
        var palindromeEnds = new Dictionary<int, List<int>>();

        for (int i = 0; i < n; i++)
            palindromeEnds[i] = new List<int>() { i };

        for (int i = 0; i < n; i++)
        {
            ExpandPalindrome(s, palindromeEnds, i, i + 1);
            ExpandPalindrome(s, palindromeEnds, i - 1, i + 1);
        }

        var results = new List<IList<string>>();
        Backtrack(s, 0, new List<string>(), results, palindromeEnds);

        return results;
    }

    private void ExpandPalindrome(string s, Dictionary<int, List<int>> palindromeEnds, int l, int r)
    {
        int n = s.Length;
        while (l >= 0 && r < n && s[l] == s[r])
        {
            palindromeEnds[l].Add(r);
            l--;
            r++;
        }
    }

    private void Backtrack(string s, int start, List<string> currentPartition, IList<IList<string>> results, Dictionary<int, List<int>> palindromeEnds)
    {
        if (start >= s.Length)
        {
            results.Add(new List<string>(currentPartition));
            return;
        }

        foreach (var end in palindromeEnds[start])
        {
            currentPartition.Add(s.Substring(start, end - start + 1));
            Backtrack(s, end + 1, currentPartition, results, palindromeEnds);
            currentPartition.RemoveAt(currentPartition.Count - 1);
        }
    }
}

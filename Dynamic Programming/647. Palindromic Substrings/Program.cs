// public class Solution
// {

//     public int CountSubstrings(string s)
//     {
//         int n = s.Length;

//         var db = new bool[n, n];
//         bool isPalindrome(int l, int r)
//         {
//             if (l >= r)
//                 return true;

//             if (db[l, r]) return db[l, r];

//             if (s[l] != s[r])
//             {
//                 db[l, r] = false;
//                 return db[l, r];
//             }

//             db[l, r] = isPalindrome(l + 1, r - 1);
//             return db[l, r];
//         }

//         int count = 0;
//         for (int i = 0; i < n; i++)
//             for (int j = i; j < n; j++)
//                 if (isPalindrome(i, j)) count++;
//         return count;

//     }
// }

// optimized solution 
public class Solution
{

    public int CountSubstrings(string s)
    {
        int n = s.Length;
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            int even = Solver(i, i + 1);
            int odd = Solver(i - 1, i + 1);
            res += even + odd + 1;
        }

        int Solver(int i, int j)
        {
            int count = 0;
            while (i >= 0 && j < n && s[i--] == s[j++])
                count++;
            return count;
        }
        return res;
    }
}


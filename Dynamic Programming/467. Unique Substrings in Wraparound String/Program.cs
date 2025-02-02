public class Solution
{
    public int FindSubstringInWraproundString(string p)
    {
        Func<char, char, bool> IsNext = (a, b) =>
          {
              if (a == 'z') return b == 'a';
              return a + 1 == b;
          };

        int maxLength = 1;
        int[] arr = new int[26];


        for (int i = 0; i < p.Length; i++)
        {
            int idx = p[i] - 'a';
            arr[idx] = Math.Max(maxLength, arr[idx]);

            if (i + 1 < p.Length && IsNext(p[i], p[i + 1])) maxLength++;
            else maxLength = 1;
        }

        int res = 0;
        for (int i = 0; i < 26; i++) res += arr[i];
        return res;
    }
}
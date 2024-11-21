using System;
using System.Globalization;

public class Solution
{
    public int NumDecodings(string s)
    {
        if (s[0] == '0') return 0;

        var m = new int[s.Length];
        Array.Fill(m, -1);

        int res = Solver(s.Length - 1);
        return res < 0 ? 0 : res;

        int Solver(int i)
        {
            if (i <= 0) return 1;
            if (m[i] != -1) return m[i];

            int ans = 0;
            int num = (s[i - 1] - '0') * 10 + (s[i] - '0');
            if (s[i] == '0')
            {
                if (s[i - 1] == '0' || num > 26)
                {
                    m[i] = -500;
                    return m[i];
                }
                ans = Solver(i - 2);
            }
            else
            {
                ans = Solver(i - 1);
                if (ans == -500)
                {
                    m[i] = -500;
                    return m[i];
                }
                if (s[i - 1] != '0' && num <= 26) ans += Solver(i - 2);
            }
            m[i] = ans;
            return ans;
        }
    }
}

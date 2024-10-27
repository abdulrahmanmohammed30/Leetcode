
class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {


        int n1 = text1.Length;
        int n2 = text2.Length;
        var m = new int[n1, n2];

        for (int i = 0; i < n1; i++)
            for (int j = 0; j < n2; j++)
                m[i, j] = -1;

        int lss = 0;

        for (int i = 0; i < n1; i++)
            for (int j = 0; j < n2; j++)
                if (text1[i] == text2[j])
                    lss = Math.Max(lss, Solver(i, j));
                    

        int Solver(int idx1, int idx2)
        {

            if (idx1 == n1 || idx2 == n2)
                return 0;

            if (m[idx1, idx2] != -1)
                return m[idx1, idx2];

            int css = 0;
            for (int i = idx1 + 1; i < n1; i++)
            {
                for (int j = idx2 + 1; j < n2; j++)
                {
                    if (text1[i] == text2[j])
                        css = Math.Max(css, Solver(i, j));
                }
            }

            m[idx1, idx2] = lss;
            return 1 + css;
        }

        return lss;
    }
};
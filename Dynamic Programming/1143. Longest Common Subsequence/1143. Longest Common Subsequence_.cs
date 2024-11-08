class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int n1 = text1.Length;
        int n2 = text2.Length;
        var m = new int[n1, n2];

        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                m[i, j] = -1;
            }
        }
        
        return Solver(0,0);
        
        int Solver(int idx1, int idx2)
        {
            if (idx1 == n1 || idx2 == n2)
                return 0;

            if (m[idx1, idx2] != -1)
                return m[idx1, idx2];

            if (text1[idx1] == text2[idx2])
                m[idx1, idx2] = 1 + Solver(idx1 + 1, idx2 + 1);
            
            else 
                m[idx1, idx2] = Math.Max(Solver(idx1 + 1, idx2), Solver(idx1, idx2 + 1));

           return  m[idx1, idx2];
        }
    }
};
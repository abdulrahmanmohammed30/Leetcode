
public class Solution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        var str = new StringBuilder();
        var dp = new int[str1.Length, str2.Length];

        for (int i = 0; i < str1.Length; i++)
        {
            for (int j = 0; j < str2.Length; j++)
            {
                dp[i, j] = -1;
            }
        }

        GetMinSequenceLength(str1, str2, 0, 0);
        GetMinSequence(str1, str2, str, 0, 0);
        return str.ToString();
        int GetMinSequenceLength(string str1, string str2, int i, int j)
        {
            if (i == str1.Length) return str2.Length - j;
            if (j == str2.Length) return str1.Length - i;

            if (dp[i, j] != -1) return dp[i, j];

            int currentMin = int.MaxValue;

            if (str1[i] == str2[j])
            {
                currentMin = 1 + GetMinSequenceLength(str1, str2, i + 1, j + 1);
            }

            currentMin = Math.Min(currentMin, 1 + GetMinSequenceLength(str1, str2, i + 1, j));

            currentMin = Math.Min(currentMin, 1 + GetMinSequenceLength(str1, str2, i, j + 1));

            dp[i, j] = currentMin;
            return currentMin;
        }
        void GetMinSequence(string str1, string str2, StringBuilder str, int i, int j)
        {
            if (i == str1.Length)
            {
                str.Append(str2.Substring(j));
                return;
            }

            if (j == str2.Length)
            {
                str.Append(str1.Substring(i));
                return;
            }

            int res = GetMinSequenceLength(str1, str2, i, j);

            if (str1[i] == str2[j])
            {
                if (1 + GetMinSequenceLength(str1, str2, i + 1, j + 1) == res)
                {
                    str.Append(str1[i]);
                    GetMinSequence(str1, str2, str, i + 1, j + 1);
                    return;
                }
            }

            if (1 + GetMinSequenceLength(str1, str2, i + 1, j) == res)
            {
                str.Append(str1[i]);
                GetMinSequence(str1, str2, str, i + 1, j);
                return;
            }

            str.Append(str2[j]);
            GetMinSequence(str1, str2, str, i, j + 1);
        }
    }
}



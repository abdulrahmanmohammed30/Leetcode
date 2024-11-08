// return from other solutons to improve thinking skills, coding skills, etc
// think about all possible cases or examples 
// avoid toy solutions which were implemented without tracing
// trace your solution with serveral examples 
// ask ai chatbots to provide you with more examples 
// save portions of code and return to it when needed such as cahe and -1 
// develop a procedure you walk into 
// always read others solutions and learn from to develop crucial 

public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        int n = word1.Length;
        int m = word2.Length;

        var cache = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++) cache[i, j] = -1;

        return Solver(0, 0);

        int Solver(int i, int j)
        {
            if (i == n || j == m)
            {
                return (n - i) + (m - j);
            }

            if (cache[i, j] != -1) return cache[i, j];

            int count = int.MaxValue;

            if (word1[i] == word2[j]) count = Solver(i + 1, j + 1);
            else
            {
                // change 
                count = Math.Min(count, 1 + Solver(i + 1, j + 1));

                // skip in i 
                count = Math.Min(count, 1 + Solver(i + 1, j));

                // skip in j 
                count = Math.Min(count, 1 + Solver(i, j + 1));

            }
            cache[i, j] = count;
            return count;
        }
    }
}
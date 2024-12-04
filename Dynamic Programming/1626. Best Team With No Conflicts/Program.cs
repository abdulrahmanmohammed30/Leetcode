public class Solution
{
    public int BestTeamScore(int[] scores, int[] ages)
    {

        var combined = ages.Zip(scores, (age, score) => new { age,  score })
                                   .OrderBy(x => x.age)
                                   .ThenBy(x => x.score)
                                   .ToList();

        int n = combined.Count();

        var dp = new int[n, n + 1];
        for (int i = 0; i < n; i++)
            for (int j = 0; j <= n; j++)
                dp[i, j] = -1;


        return Solver(0, n);

        int Solver(int idx, int prevIdx)
        {
            if (idx == n) return 0;

            if (dp[idx, prevIdx] != -1)
                return dp[idx, prevIdx];

            int leave = Solver(idx + 1, prevIdx);

            int pick = 0;
            if (prevIdx == n || combined[prevIdx].age == combined[idx].age || combined[idx].score >= combined[prevIdx].score)
                pick = combined[idx].score + Solver(idx + 1, idx);

            return dp[idx, prevIdx] = Math.Max(leave, pick);
        }

    }
}
public class Solution
{
    public int MinSteps(int n)
    {
        if (n == 1) return 0;

        // state: 0 -> copy - cannot copy
        //        1 -> paste - can copy
        // Start with 0 

        return 1 + Solver(1, 1, false);
        // number of states: n * n * 2
        int Solver(int cur, int LastCopied, bool state)
        {
            if (cur > n)
                return int.MaxValue / 12;

            if (cur == n)
                return 0;

            // you always can paste 
            // you copy by the current cur which is wrong 
            // you need to maintain the last value that was copied 
            // After pasting, you can keep paste again or copy  
            // so the copy state was set to true 

            var res = 1 + Solver(cur + LastCopied, LastCopied, true);

            // You can copy
            // you cannot do another copy without pasting first 
            // so the copying state was set to false 
            // reset the LastCopied 
            if (state)
                res = Math.Min(res, 1 + Solver(cur, cur, false));

            return res;
        }
    }
}
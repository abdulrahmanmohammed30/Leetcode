public class Solution {
    public int LengthOfLIS(int[] nums) {
    
        int n=nums.Count();
        var m = new int[n,n + 1];
        for (int i = 0; i<n;i++)
           for (int j = 0; j<n;j++)
                 m[i,j]=-1;
        
        int Solver(int idx, int pre) {
           if (idx == nums.Count())
                return 0;

            if (m[idx,pre + 1] != -1)
               return m[idx, pre + 1];


            int leave=Solver(idx + 1, pre);
            int pick=0;

            if (pre == -1 || nums[idx] > nums[pre]) 
               pick=1+Solver(idx + 1, idx);
             
              m[idx, pre + 1]=Math.Max(leave,pick);
            
              return Math.Max(leave,pick);
        }

        return Solver(0, -1);
    }
}
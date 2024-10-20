using System.Text;

namespace Problem_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            // test your solution
            Console.WriteLine(new Solution().IsAdditiveNumber("112358"));
            Console.WriteLine(new Solution().IsAdditiveNumber("199100199"));

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public bool IsAdditiveNumber(string num)
        {
            return Backtrack(num, 0, 0, 0, 0);
        }

        private bool Backtrack(string num, int index, long prevNum, long sum, int count)
        {
            if (index == num.Length)
            {
                return count > 2;
            }

            long currentNum = 0;
            for (int i = index; i < num.Length; i++)
            {
                if (i != index && num[index] == '0') break; // No leading zeros except for 0 itself

                currentNum = currentNum * 10 + (num[i] - '0');

                if (count >= 2)
                {
                    if (currentNum < sum) continue;
                    if (currentNum > sum) break;
                }

                if (Backtrack(num, i + 1, currentNum, prevNum + currentNum, count + 1))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

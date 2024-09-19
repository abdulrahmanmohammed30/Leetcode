using System.Text;

namespace _784_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = new Solution().LetterCasePermutation("3z4");
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }
    }

    public class Solution
    {

        void solver(string s, int index, List<string>res, StringBuilder cur) {
            
            if (index == s.Length)
            {
                res.Add(cur.ToString());
                return;
            }

         
            if (s[index] > '9')
            {
                cur.Append(s[index] > 'Z' ? Char.ToUpper(s[index]) : Char.ToUpper(s[index]));
                solver(s, index + 1, res, cur);
                cur.Remove(index, 1);
            }

            cur.Append(s[index]);
            solver(s, index + 1, res, cur);
            cur.Remove(index, 1);
        }
        public IList<string> LetterCasePermutation(string s)
        {
            var res = new List<string>();
            solver(s, 0, res, new StringBuilder());
            return res;
        }
    }
}

namespace _797._All_Paths_from_Source_To_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = new Solution().AllPathsSourceTarget([[4, 3, 1], [3, 2, 4], [3], [4], []]);
            foreach(var i in res)
            {
                foreach(var j in i)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
    public class Solution
    {

        void Solver(int[][] graph, int index, int target, List<int> path, List<IList<int>> paths) {

            if (index == target)
            {
                paths.Add(new List<int>(path));
                return;
            }

            foreach(var i in graph[index])
            {
                path.Add(i);
                Solver(graph, i, target, path, paths);
                path.Remove(i);
            }
        }
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {

            var paths = new List<IList<int>>();
            var path=new List<int>() {0};

             Solver(graph, 0, graph.Count() - 1, path, paths);

            //return new List<IList<int>> { new List<int>() };
            return paths;
        }
    }
}

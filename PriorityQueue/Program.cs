
using System.Collections.Generic;
using System.Linq;

namespace CsharpTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Solution solution = new Solution();
            solution.solution(new string[] { "I 16", "I -5643", "D -1", "D 1", "D 1", "I 123", "D -1" });
        }

        public class Solution
        {
            public int[] solution(string[] operations)
            {
                List<int> answer = new List<int>();

                List<int> numList = new List<int>();

                // I 숫자   큐에 주어진 숫자를 삽입합니다.
                // D 1	    큐에서 최댓값을 삭제합니다.
                // D -1	    큐에서 최솟값을 삭제합니다.

                foreach (string operation in operations)
                {
                    var item = operation.Split(" ");
                    if (item[0] == "I")
                    {
                        var isNum = int.TryParse(item[1], out int result);
                        if (isNum)
                            numList.Add(result);
                    }

                    if (item[0] == "D")
                    {
                        if (numList.Count == 0)
                            continue;

                        if (item[1] == "1")
                        {
                            var max = numList.Max();

                            // 최댓값 삭제
                            numList.Remove(max);
                        }
                        else
                        {
                            var min = numList.Min();
                            // 최솟값 삭제
                            numList.Remove(min);
                        }
                    }
                }

                if (numList.Count > 0)
                {

                    var max = numList.Max();
                    var min = numList.Min();

                    answer.Add(max);
                    answer.Add(min);
                }
                else
                {
                    answer.Add(0);
                    answer.Add(0);
                }

                return answer.ToArray();
            }

            // 다른 사람 풀이
            public int[] solution2(string[] arguments)
            {
                List<int> lst = new List<int>();
                foreach (string cmd in arguments)
                {
                    string[] str = cmd.Split(' ');
                    if (str[0].Equals("I"))
                        lst.Add(int.Parse(str[1]));
                    else if (lst.Count() > 0 && str[1] == "1")
                        lst.Remove(lst.Max());
                    else if (lst.Count() > 0 && str[1] == "-1")
                        lst.Remove(lst.Min());
                }
                return lst.Count() == 0 ? new int[] { 0, 0 } : new int[] { lst.Max(), lst.Min() };
            }

        }
    }
}
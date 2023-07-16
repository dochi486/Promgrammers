using System;
using System.Linq;

namespace Painting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            solution.solution(5, 4, new[] {1, 3});
        }
    }

    public class Solution
    {
        public int solution(int n, int m, int[] section)
        {
            var answer = 0;
            var max = 0;

            var sections = section.ToList();

            sections.ForEach(x =>
            {
                if (x > max)
                {
                    answer++;
                    max = x + m - 1;
                }
            });


            // 롤러의 길이 m미터

            // 최소 공배수..?

            // 벽을 n개의 구역으로 나눠서 n번까지의 번호로
            //List<int> wall = new List<int>();
            //for (int i = 1; i <= n; i++)
            //{
            //    wall.Add(i);
            //}

            //int painted = 0;
            // wall에서 section의 원소로 담긴 부분을 칠한다.

            //for (int j = 0; j < section.Length; j++)
            //{
            //    if (painted == 0)
            //    {
            //        answer++;
            //    }

            //    // section의 원소에 해당하는 wall의 인덱스를 가져오고
            //    var wallIdx = wall.IndexOf(section[j]);
            //    painted = wall[wallIdx] + m - 1;

            //    if (j != 0)
            //    {
            //        var foreWallIdx = wall.IndexOf(section[j - 1]);
            //        if (painted > wall[foreWallIdx] + m - 1)
            //        {
            //            if (painted > wall.Count)
            //                break;
            //            else
            //                answer++;
            //        }
            //    }
            //}


            //while (sections.Count > 0)
            //{
            //    //for (int i = 0; i < sections.Count; i++)
            //    //{
            //    //    int wallIdx = 0;
            //    //    if (wall.Contains(sections[i]))
            //    //    {
            //    //        wallIdx = wall.IndexOf(sections[i]);
            //    //        painted = wall[wallIdx] + m - 1;
            //    //    }

            //    //    // 이미 칠한 벽은 지우고
            //    //    if (wall.Count > painted)
            //    //    {
            //    //        wall.RemoveRange(wallIdx, painted);
            //    //    }
            //    //    sections.RemoveAt(i);
            //    //    answer++;
            //    //}

            //    int max = 0;
            //    int idx = 0;

            //    for (int i = 0; i < sections.Count; i++)
            //    {
            //        if (sections[i] <= sections[0] + m - 1)
            //            idx = i;
            //        else
            //        {
            //            idx = i - 1;
            //            break;
            //        }
            //    }

            //    for (int i = 0; i < idx + 1; i++)
            //    {
            //        if(sections.Count > idx + 1)
            //            sections.RemoveAt(sections[0]);
            //    }

            //    answer++;
            //}

            return answer;
        }
    }
}
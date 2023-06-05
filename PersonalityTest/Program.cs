using System;
using System.Collections.Generic;

namespace PersonalityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            string[] survey = { "AN", "CF", "MJ", "RT", "NA" };
            int[] choices = { 5, 3, 2, 7, 5 };
            solution.solution(survey, choices);
        }
    }

    public class Solution
    {
        public string solution(string[] survey, int[] choices)
        {
            string answer = "";

            // 4개의 지표 
            Dictionary<string, int> points = new Dictionary<string, int>();

            points.Add("R", 0);
            points.Add("T", 0);

            points.Add("C", 0);
            points.Add("F", 0);

            points.Add("J", 0);
            points.Add("M", 0);

            points.Add("A", 0);
            points.Add("N", 0);

            // 1번 지표 : R / T
            // 2번 지표 : C / F
            // 3번 지표 : J / M
            // 4번 지표 : A / N

            // survey의 왼쪽은 choices가 1~3일 때 점수 얻음
            // survey의 오른쪽은 choices가 5~7일 때 점수 얻음
            for (int t = 0; t < survey.Length; t++)
            {
                switch (choices[t])
                {
                    case 1:
                        points[survey[t][0].ToString()] += 3;
                        break;
                    case 2:
                        points[survey[t][0].ToString()] += 2;
                        break;
                    case 3:
                        points[survey[t][0].ToString()]++;
                        break;
                    case 4:
                        break;
                    case 5:
                        points[survey[t][1].ToString()]++;
                        break;
                    case 6:
                        points[survey[t][1].ToString()] += 2;
                        break;
                    case 7:
                        points[survey[t][1].ToString()] += 3;
                        break;
                }
                
            }

            // 각 문항의 유형이 받은 점수를 더해서 
            // 지표 순서대로 나타내기

            string[] result = new string[4];

            // 동점일 경우 지표 순서대로 처리
            result[0] = points["R"] >= points["T"] ? "R" : "T";
            result[1] = points["C"] >= points["F"] ? "C" : "F";
            result[2] = points["J"] >= points["M"] ? "J" : "M";
            result[3] = points["A"] >= points["N"] ? "A" : "N";

            answer = string.Concat(result[0], result[1], result[2], result[3]);

            return answer; ;
        }
    }
}

using System;
using System.Collections.Generic;

namespace PrivacyTermSave
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            string today = "2022.05.19";
            string[] terms = { "A 6", "B 12", "C 3" };
            string[] privacies = { "2021.05.02 A", "2021.07.01 B", "2022.02.19 C", "2022.02.20 C" };
            solution.solution(today, terms, privacies);
        }
    }

    public class Solution
    {

        private static readonly int LAST_MONTH = 12;
        private static readonly int LAST_DAY = 28;
        private static int TodayYear;
        private static int TodayMonth;
        private static int TodayDay;

        public int[] solution(string today, string[] terms, string[] privacies)
        {
            var eachTerms = new Dictionary<string, int>();
            string[] splitResult;
            List<int> expiredTypeNums = new List<int>();

            // 오늘 날짜 세팅
            splitResult = today.Split('.');
            TodayYear = int.Parse(splitResult[0]);
            TodayMonth = int.Parse(splitResult[1]);
            TodayDay = int.Parse(splitResult[2]);

            // terms 맵 세팅
            int tempCount = terms.Length;
            for (int i = 0; i < tempCount; i++)
            {
                splitResult = terms[i].Split(' ');
                eachTerms[splitResult[0]] = int.Parse(splitResult[1]);
            }

            tempCount = privacies.Length;
            string date = "";
            string type = "";
            for (int i = 0; i < tempCount; i++)
            {
                splitResult = privacies[i].Split(' ');
                date = splitResult[0];
                type = splitResult[1];
                if (IsExpired(date, eachTerms[type]))
                {
                    expiredTypeNums.Add(i + 1);
                }
            }

            return expiredTypeNums.ToArray();
        }

        private bool IsExpired(string date, int termMonth)
        {
            var splitResult = date.Split('.');
            int year = int.Parse(splitResult[0]);
            int month = int.Parse(splitResult[1]);
            int day = int.Parse(splitResult[2]);

            // 모두 일자로 바꿔서 비교
            int gapDay =
                (TodayYear - year) * LAST_MONTH * LAST_DAY
                + (TodayMonth - month) * LAST_DAY
                + (TodayDay - day);

            // 
            return gapDay >= termMonth * LAST_DAY;
        }
    }
}

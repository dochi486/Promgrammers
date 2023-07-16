using System;
using System.Collections.Generic;

namespace TermsOfPrivacy
{
    internal class Privacy
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            var today = "2020.01.01";
            string[] terms = {"Z 3", "D 5"};
            string[] privacies = {"2019.01.01 D", "2019.11.15 Z", "2019.08.02 D", "2019.07.01 D", "2018.12.28 Z"};
            solution.solution(today, terms, privacies);
        }
    }

    public class Solution
    {
        private const int DAY = 28;
        private const int MONTH = 12;

        public int[] solution(string today, string[] terms, string[] privacies)
        {
            var indexesToDelete = new List<int>();
            var privacyTerms = new Dictionary<string, List<string>>();
            var termsConditions = new Dictionary<string, string>();

            // terms 유효기간
            // 각 조항의 키 - 기간 딕셔너리
            for (var i = 0; i < terms.Length; i++)
            {
                var term = terms[i].Split(" ");
                // 조항 - 개월 수
                if (termsConditions.ContainsKey(term[0]))
                    continue;
                termsConditions.Add(term[0], term[1]);
            }

            var dates = new List<string>();
            // privacies 개인정보
            for (var i = 0; i < privacies.Length; i++)
            {
                var privacy = privacies[i].Split(" ");
                // 조항 - 날짜
                if (!privacyTerms.ContainsKey(privacy[1])) privacyTerms[privacy[1]] = new List<string>();

                privacyTerms[privacy[1]].Add(privacy[0]);
            }

            // 오늘 날짜를 구해서 각각 연도, 월, 일로 가지고 있고
            var date = today.Split(".");
            var year = int.Parse(date[0]);
            var month = int.Parse(date[1]);
            var day = int.Parse(date[2]);

            var elapsedDays = 0;
            var conditionDays = 0;
            var index = 0;


            // 여기 맵을 루프돌 게 아니라 배열 privacies를 돌아야 인덱스가 딱 맞는다
            //foreach (var item in privacyTerms)
            //{
            //    var condition = termsConditions[item.Key];
            //    // 개월 수 * 일
            //    conditionDays = int.Parse(condition) * DAY;

            //    for (int i = 0; i < item.Value.Count; i++)
            //    {
            //        var contractDate = item.Value[i].Split('.');

            //        var contractYear = int.Parse(contractDate[0]);
            //        var contractMonth = int.Parse(contractDate[1]);
            //        var contractDay = int.Parse(contractDate[2]);

            //        elapsedDays = (year - contractYear) * MONTH * DAY + (month - contractMonth) * DAY + (day - contractDay);

            //        if (conditionDays <= elapsedDays)
            //            indexesToDelete.Add(index + 1);

            //        index++;
            //    }
            //}

            foreach (var item in privacies)
            {
                var privacy = item.Split(" ");
                var condition = termsConditions[privacy[1]];
                conditionDays = int.Parse(condition) * DAY;

                var contractSignedDate = privacy[0].Split('.');
                var contractSignedYear = int.Parse(contractSignedDate[0]);
                var contractSignedMonth = int.Parse(contractSignedDate[1]);
                var contractSignedDay = int.Parse(contractSignedDate[2]);

                elapsedDays = (year - contractSignedYear) * MONTH * DAY + (month - contractSignedMonth) * DAY +
                              (day - contractSignedDay);

                if (conditionDays <= elapsedDays)
                    indexesToDelete.Add(index + 1);

                index++;
            }

            return indexesToDelete.ToArray();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace TermsOfPrivacy
{
    class Privacy
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
        private const int DAY = 28;
        private const int MONTH = 12;

        public int[] solution(string today, string[] terms, string[] privacies)
        {
            List<int> indexesToDelete = new List<int>();
            Dictionary<string, string> privacyTerms = new Dictionary<string, string>();
            Dictionary<string, string> termsConditions = new Dictionary<string, string>();

            // terms 유효기간
            // 각 조항의 키 - 기간 딕셔너리
            for (int i = 0; i < terms.Length; i++)
            {
                var term = terms[i].Split(" ");
                // 조항 - 개월 수
                if (termsConditions.ContainsKey(term[0]))
                {
                    continue;
                }
                else
                {
                    termsConditions.Add(term[0], term[1]);
                }
            }

            // privacies 개인정보
            for (int i = 0; i < privacies.Length; i++)
            {
                var privacy = privacies[i].Split(" ");
                // 조항 - 날짜
                if (privacyTerms.ContainsKey(privacy[1]))
                {
                    continue;
                }
                else
                {
                    privacyTerms.Add(privacy[1], privacy[0]);
                }
            }

            // 오늘 날짜를 구해서 각각 연도, 월, 일로 가지고 있고
            var date = today.Split(".");
            var year = date[0];
            var month = date[1];
            var day = date[2];



            //string[] contractDate = new string[3];

            //for (int i = 0; i < privacies.Length; i++)
            //{
            //    var privacy = privacies[i].Split(" ");

            //    // privacies의 배열 요소의 각 조항을 확인하고 기간을 가져와서
            //    var duration = termsConditions.FirstOrDefault(x => x.Key == privacy[1]).Value;
            //    int.TryParse(duration, out int durationValue);

            //    // privacies의 배열 요소의 날짜와 today를 비교하고 그 값이 기간보다 크면 삭제한다. 
            //    int.TryParse(year, out int yearResult);
            //    int.TryParse(privacyTerms[privacy[1]].Split(".")[0], out int privacyYear);
            //    //var yearSubtract = yearResult - privacyYear;

            //    int.TryParse(month, out int monthResult);
            //    int.TryParse(privacyTerms[privacy[1]].Split(".")[1], out int privacyMonth);
            //    //var monthSubtract = monthReseult - privacyMonth;

            //    int.TryParse(day, out int dayResult);
            //    int.TryParse(privacyTerms[privacy[1]].Split(".")[2], out int privacyDay);
            //    //var daySubtract = dayResult - privacyDay;

            //    // durationValue만큼 동의 날짜에 더하고 그 날짜가 today보다 큰지 확인하기... 
            //    //var newMonth = privacyMonth + durationValue;

            //    //if(durationValue < 12)
            //    //{
            //    //    if (24 > newMonth && newMonth > 12)
            //    //    {
            //    //        privacyYear++;
            //    //    }
            //    //    else if (newMonth > 24)
            //    //    {
            //    //        privacyYear += 2;
            //    //    }

            //    //    if (monthResult < newMonth)
            //    //    {
            //    //        indexesToDelete.Add(i + 1);
            //    //    }
            //    //    else if (monthResult == newMonth)
            //    //    {
            //    //        if (privacyYear == yearResult && privacyDay == dayResult)
            //    //        {
            //    //            indexesToDelete.Add(i + 1);
            //    //        }
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    // 기간이 1년 이상일 때?
            //    //    //if()
            //    //}
            //}
            return indexesToDelete.ToArray();
        }
    }
}

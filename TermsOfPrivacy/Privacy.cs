using System;
using System.Collections.Generic;

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
        public int[] solution(string today, string[] terms, string[] privacies)
        {
            int[] answer = new int[] { };
            Dictionary<string, string> privacyTerms = new Dictionary<string, string>();
            Dictionary<string, string> termsConditions = new Dictionary<string, string>();
            string condition = "A";

            // terms 유효기간
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
                    condition = terms[0];
                    termsConditions.Add(term[0], term[1]);
                }
            }


            var date = today.Split(".");
            var year = date[0];
            var month = date[1];
            var day = date[2];


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
                    int.TryParse(year, out int yearResult);
                    int.TryParse(privacyTerms[privacy[1]].Split(".")[0], out int privacyYear);
                    var yearSubtract = yearResult - privacyYear;

                    int.TryParse(month, out int monthReseult);
                    int.TryParse(privacyTerms[privacy[1]].Split(".")[1], out int privacyMonth);

                    var monthSubtract = monthReseult - privacyMonth;

                    for (int j = 0; j < privacy[1].Length; j++)
                    {
                        //int.TryParse(date[i][j].ToString, out int dateReseult);
                        int.TryParse(privacyTerms[privacy[1]].Split(".")[2], out int privacyDate);

                        var dateSubtract = dateReseult - privacyDate;
                    }

                }
            }

            // today
 
            

            //privacyTerms 날짜 분해할지 고민
            {
                // A 6
                // B 12
                // C 3
                
                // 5 -06
                // 07 - 12 
                // 2 -3
              

            }



            return answer;
        }
    }
}

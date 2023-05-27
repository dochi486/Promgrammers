using System;
using System.Collections.Generic;

namespace TermsOfPrivacy
{
    class Privacy
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public int[] solution(string today, string[] terms, string[] privacies)
        {
            int[] answer = new int[] { };
            Dictionary<string, string> privacyTerms = new Dictionary<string, string>();
            Dictionary<string, string> termsConditions = new Dictionary<string, string>();
            

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


            var date = today.Split(".");
            



            return answer;
        }
    }
}

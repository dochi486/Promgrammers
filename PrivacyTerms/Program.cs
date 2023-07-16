using System;

namespace PrivacyTerms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Solution solution = new Solution();
            // string today = "2022.05.19";
            // string[] terms = { "A 6", "B 12", "C 3" };
            // string[] privacies = { "2021.05.02 A", "2021.07.01 B", "2022.02.19 C", "2022.02.20 C" };
            // solution.solution(today, terms, privacies);
        }
    }
    //
    // public class Solution
    // {
    //     public int[] solution(string today, string[] terms, string[] privacies)
    //     {
    //         // 모든 달은 28일까지만 있음
    //         int[] answer = new int[] { };
    //         Dictionary<string, string> privacyTerms = new Dictionary<string, string>();
    //         List<Tuple<string, string, int>> privacyTermsTupleList = new List<Tuple<string, string, int>>();
    //         Dictionary<string, string> termsConditions = new Dictionary<string, string>();
    //         Dictionary<DateTime, int> dateToDelete = new Dictionary<DateTime, int>();
    //         List<int> indexes = new List<int>();
    //
    //         // terms 유효기간
    //         for (int i = 0; i < terms.Length; i++)
    //         {
    //             var term = terms[i].Split(" ");
    //             // 조항 - 개월 수
    //             if (termsConditions.ContainsKey(term[0]))
    //             {
    //                 continue;
    //             }
    //             else
    //             {
    //                 termsConditions.Add(term[0], term[1]);
    //             }
    //         }
    //
    //         // privacies 개인정보
    //         for (int i = 0; i < privacies.Length; i++)
    //         {
    //             var privacy = privacies[i].Split(" ");
    //             // 조항 - 날짜
    //             if (privacyTerms.ContainsKey(privacy[1]))
    //             {
    //                 continue;
    //             }
    //             else
    //             {
    //                 for (int j = 0; j < privacy[1].Length; j++)
    //                 {
    //                     var dateToSplit = privacy[1][j];
    //                 }
    //                 privacyTerms.Add(privacy[1], privacy[0]);
    //                 privacyTermsTupleList.Add(new Tuple<string, string, int>(privacy[1], privacy[0], i + 1));
    //             }
    //         }
    //
    //
    //         // 약관 조항에 따라서 처리 다르게 해준다.
    //         // 분기 타서 privacies에서 받은 날짜 더하기 약관 조항의 개월 수
    //         // 그러면 삭제할 날짜 나오고
    //         foreach (var item in privacyTerms)
    //         {
    //             // 개인 정보의 약관 조항 확인하기
    //             // item value = a , key = 날짜 
    //             // termsconditions key = a , value = 날짜
    //             // 같으면 해당하는 item의 인덱스를 저장한다.
    //             var durations = DateTime.Parse(termsConditions[item.Key]);
    //             var savedDate = item.Value;
    //
    //             var value = privacyTerms.FirstOrDefault(x => x.Key == item.Key);
    //             
    //             var foundItem = privacyTermsTupleList.FirstOrDefault(x => x.Item1 == item.Key);
    //
    //             var contract = DateTime.Parse(savedDate) - DateTime.Parse(today);
    //
    //             if (contract.CompareTo(durations) == 1)
    //             {
    //                 dateToDelete.Add(DateTime.Parse(item.Key), foundItem.Item3);
    //
    //             }
    //
    //         }
    //
    //         // 인덱스 + 1 값을 오름차순 정렬해서 리턴
    //         //answer.OrderBy(x => x.);
    //
    //         return answer;
    //     }
    // }
}
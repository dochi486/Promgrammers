using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    
    public class Solution
    {
        public int[] solution(string[] id_list, string[] report, int k)
        {
            int[] answer = new int[id_list.Length];

            report = report.Distinct().ToArray();

            // report를 신고자, 불량 유저로 나눈 컨테이너
            Dictionary<string, List<string>> userContainer = new Dictionary<string, List<string>>();
            // 신고 당한 모든 유저 목록
            var allReportedUser = new Dictionary<string, int>();

            // id_list의 유저들이 불량 유저를 신고한 내역 report에서
            for (int i = 0; i < report.Length; i++)
            {
                var users = report[i].Split(" ");
                if (!userContainer.ContainsKey(users[0]))
                {
                    userContainer[users[0]] = new List<string>();
                }
                userContainer[users[0]].Add(users[1]);

                if (!allReportedUser.ContainsKey(users[1]))
                {
                    allReportedUser[users[1]] = 0;
                }
                allReportedUser[users[1]]++;
            }

            // k번 이상 신고 받은 유저는 활동이 정지된다.
            List<string> blockedUser = new List<string>();


            // 정지 당한 유저만 따로 리스트에 정리...
            foreach (var item in allReportedUser)
            {
                if (item.Value >= k)
                {
                    blockedUser.Add(item.Key);
                }
            }

            // 알림 메일을 발송한 횟수를 리턴한다.

            var sortedBlockList = blockedUser.Distinct().ToList();
            List<int> answerList = new List<int>();
            int mailCount = 0;
            //전체 유저 중에서
            foreach (var reporter in id_list)
            {
                mailCount = 0;

                // 정지 당한 목록 순회
                for (int i = 0; i < sortedBlockList.Count; i++)
                {
                    // 정지 대상을 신고한 신고자로 존재하는지
                    if (userContainer.ContainsKey(reporter))
                    {
                        var element = userContainer[reporter].Find(x => x == sortedBlockList[i]);
                        if (element != null) 
                            mailCount++;
                    }
                }
                answerList.Add(mailCount);
            }
            return answerList.ToArray();
        }
    }
 
}

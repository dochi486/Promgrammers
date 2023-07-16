using System;
using System.Collections.Generic;
using System.Linq;

namespace Promgrammers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            string[] id_list = {"muzi", "frodo", "apeach", "neo"};
            string[] report = {"muzi frodo", "apeach frodo", "frodo neo", "muzi neo", "apeach muzi"};
            solution.solution(id_list, report, 2);
        }
    }

    public class Solution
    {
        public int[] solution(string[] id_list, string[] report, int k)
        {
            int[] answer = { };

            var userContainer = new Dictionary<string, List<string>>();
            var allReportedUser = new Dictionary<string, bool>();

            for (var i = 0; i < report.Length; i++)
            {
                var users = report[i].Split(" ");
                if (!userContainer.ContainsKey(users[0])) userContainer[users[0]] = new List<string>();

                // 중복 체크
                if (userContainer[users[0]].Contains(users[1])) continue;

                userContainer[users[0]].Add(users[1]);
                allReportedUser.Add(users[1], true);
            }


            // k번 이상 신고 받은 유저는 활동이 정지된다.
            var blockedUser = new List<string>();

            // 정지 당한 유저만 따로 리스트에 정리...
            //for (int i = 0; i < allReportedUser.Count; i++)
            //{
            //    var count = allReportedUser.FindAll(x => x.Contains(allReportedUser[i]));
            //    if (count.Count >= k)
            //    {
            //        blockedUser.Add(allReportedUser[i]);
            //    }
            //} 

            // 알림 메일을 발송한 횟수를 리턴한다.

            //Dictionary<string, int> mailCounts = new Dictionary<string, int>();

            //// 전체 유저 중에서
            //foreach (var item in id_list)
            //{
            //    int mailCount = 0;
            //    List<int> answerList = new List<int>();

            //    var sortedBlockList = blockedUser.Distinct().ToList();

            //    // 정지당한 유저가 아니라 메일 보낸 유저를 찾아야함... 
            //    for (int i = 0; i < sortedBlockList.Count; i++)
            //    {
            //        // 정지당한 유저를 현재 item(id_list의 유저)가 신고했는지 확인한다. 
            //        // userContainer가 report를 정리한 딕셔너리이기 때문에 여기서 확인
            //        for (int j = 0; j < userContainer.Keys.Count; j++)
            //        {
            //            // user가 신고했는지 확인
            //            var element = userContainer.ElementAt(j).Value.Find(x => x == sortedBlockList[i]);
            //            if(element != null)
            //            {
            //                // element가 null이 아니면 신고한 것이므로 횟수 증가
            //                mailCount++;
            //            }

            //            mailCounts.Add(userContainer.ElementAt(j).Key, mailCount);
            //            answerList.Add(mailCount);
            //        }
            //    }
            //    answer = answerList.ToArray();
            //}

            var sortedBlockList = blockedUser.Distinct().ToList();
            var answerList = new List<int>();
            var mailCount = 0;


            for (var i = 0; i < id_list.Length; i++)
            {
                mailCount = 0;

                // 정지 당한 목록 순회
                for (var j = 0; j < sortedBlockList.Count; j++)
                    // reporter가 신고한 사람이 정지 당했는지 확인
                    if (userContainer.ContainsKey(id_list[i]))
                    {
                        var element = userContainer[id_list[i]].Find(x => x == sortedBlockList[j]);
                        if (element != null)
                            mailCount++;
                    }

                answerList.Add(mailCount);
            }

            return answerList.ToArray();
        }
    }
}
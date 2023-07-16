using System;
using System.Collections.Generic;

namespace Run
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            string[] players = {"mumu", "soe", "poe", "kai", "mine"};
            string[] callings = {"kai", "kai", "mine", "mine"};
            solution.solution(players, callings);
        }
    }

    public class Solution
    {
        public string[] solution(string[] players, string[] callings)
        {
            var playerRanks = new Dictionary<string, int>();

            var tempLength = players.Length;
            for (var j = 0; j < tempLength; j++)
                // 순위랑 선수 이름을 맵에 넣어주고 
                playerRanks.Add(players[j], j);
            // 플레이어 순위가 담긴 players 배열의 요소 중에서
            //for (int i = 1; i < players.Length; i++)
            //{
            //    // player의 요소를 callings에서 찾았다면
            //    if (players[i] == callings[j])
            //    {
            //        // players에서도 한 칸씩 앞으로 당겨준다.... 
            //        var temp = players[i];
            //        players[i] = players[i - 1];
            //        players[i - 1] = temp;
            //    }
            //}
            foreach (var item in callings)
                if (playerRanks.ContainsKey(item))
                    playerRanks[item]--;
            // 딕셔너리 수정... 

            return players;
        }
    }


    //public class Solution
    //{
    //    public string[] solution(string[] players, string[] callings)
    //    {
    //        string[] answer = new string[] { };
    //        Dictionary<string, int> dict = new Dictionary<string, int>();

    //        for (int i = 0; i < players.Length; i++)
    //        {
    //            dict[players[i]] = i;
    //        }

    //        foreach (string c in callings)
    //        {
    //            int index = dict[c];
    //            dict[c]--;
    //            dict[players[index - 1]]++;
    //            string temp = players[index];
    //            players[index] = players[index - 1];
    //            players[index - 1] = temp;
    //        }

    //        return players;
    //    }
    //}
}
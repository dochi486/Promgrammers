using System;
using System.Collections.Generic;
using System.Linq;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            string[] players = { "mumu", "soe", "poe", "kai", "mine" };
            string[] callings = { "kai", "kai", "mine", "mine" };
            solution.solution(players, callings);
        }
    }

    public class Solution
    {
        public string[] solution(string[] players, string[] callings)
        {
            Dictionary<int, string> playerRanks = new Dictionary<int, string>();

            var tempLength = players.Length;
            for (int j = 0; j < tempLength; j++)
            {
                playerRanks.Add(j, players[j]);

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
            }

            return players;
        }
    }
}

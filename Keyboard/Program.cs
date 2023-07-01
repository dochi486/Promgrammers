using System;
using System.Collections.Generic;
using System.Linq;

namespace Keyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            solution.solution(new string[] { "ABACD", "BCEFD" }, new string[] { "ABCD","AABB" });
        }
    }


    public class Solution
    {
        public int[] solution(string[] keymap, string[] targets)
        {
            var answerList = new List<int>();

            if (keymap.Length < 1 || keymap.Length > 100)
                return null;

            if (targets.Length < 1 || targets.Length > 100)
                return null;

            var keyList = keymap.ToList();

            // targets에 있는 char를 keymap에서 찾아서 (가장 가까운 걸로)
            for (int i = 0; i < targets.Length; i++)
            {
                for (int j = 0; j < targets[i].Length; j++)
                {
                    if(false == keyList.Contains(targets[i][j].ToString()))
                    {
                        answerList.Add(-1);
                        break;
                    }
                    else
                    {
                        // 몇 번째 인덱스인지 받아서 answer에 저장
                        answerList.Add(keyList.IndexOf(targets[i][j].ToString()));
                    }
                }
            }

            return answerList.ToArray();
        }
    }
}

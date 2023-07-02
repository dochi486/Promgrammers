using System;
using System.Collections.Generic;
using System.Linq;

namespace Keyboard
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            solution.solution(new[] { "ABACD", "BCEFD" }, new[] { "ABCD", "AABB" });
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

            for (var k = 0; k < keyList.Count; k++)
                // targets에 있는 char를 keymap에서 찾아서 (가장 가까운 걸로)
            for (var i = 0; i < targets.Length; i++)
            for (var j = 0; j < targets[i].Length; j++)
                if (false == keyList[k].Contains(targets[i][j]))
                {
                    answerList.Add(-1);
                    break;
                }
                else
                {
                    // 몇 번째 인덱스인지 받아서 answer에 저장
                    answerList.Add(keyList[k].IndexOf(targets[i][j]) + 1);
                }

            return answerList.ToArray();
        }
    }
}
using System;
using System.Collections.Generic;

namespace Keyboard
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            solution.solution(new[] {"ABACD", "BCEFD"}, new[] {"ABCD", "AABB"});
        }
    }


    public class Solution
    {
        public int[] solution(string[] keymap, string[] targets)
        {
            var answer = new int[keymap.Length];
            var newKeymap = new Dictionary<int, List<char>>();

            // keymap에 있는 원소 중에서 
            // keymap을 먼저 정리
            for (var i = 0; i < keymap.Length; i++)
            {
                newKeymap[i] = new List<char>();

                for (var j = 0; j < keymap[i].Length; j++) newKeymap[i].Add(keymap[i][j]);
            }

            for (var i = 0; i < newKeymap.Count; i++)
                // targets의 원소를 찾아서
            for (var k = 0; k < targets.Length; k++)
            for (var j = 0; j < targets[k].Length; j++)
            {
                var found = newKeymap[i].Find(x => x == targets[k][j]);
                if (found != '\0')
                {
                    // 인덱스를 가져오고
                    var foundIdx = newKeymap[i].IndexOf(found);

                    // 그 인덱스의 값을 더해준다. (해당하는 keymap 배열 요소의 인덱스와 일치하게)
                    answer[k] += foundIdx + 1;
                }
                else
                {
                    answer[k] = -1;
                }
            }

            return answer;
        }
    }


    //public class Solution
    //{
    //    private Dictionary<char, int> _indexes = new Dictionary<char, int>();

    //    public int[] solution(string[] keymap, string[] targets)
    //    {
    //        var count = keymap.Length;
    //        int stringLength = 0;
    //        for (int i = 0; i < count; i++)
    //        {
    //            stringLength = keymap[i].Length;
    //            for (int j = 0; j < stringLength; j++)
    //            {
    //                if (_indexes.ContainsKey(keymap[i][j])
    //                    && _indexes[keymap[i][j]] < j) continue;
    //                _indexes[keymap[i][j]] = j;
    //            }
    //        }

    //        count = targets.Length;
    //        int[] answer = new int[count];
    //        for (int i = 0; i < count; i++)
    //        {
    //            answer[i] = GetIndexSum(targets[i]);
    //        }
    //        return answer;
    //    }

    //    private int GetIndexSum(string target)
    //    {
    //        int totalIndex = 0;
    //        int stringLength = target.Length;
    //        for (int i = 0; i < stringLength; i++)
    //        {
    //            if (!_indexes.ContainsKey(target[i])) return -1;
    //            totalIndex += _indexes[target[i]] + 1;
    //        }
    //        return totalIndex;
    //    }
    //}

    //public class Solution
    //{
    //    public int[] solution(string[] keymap, string[] targets)
    //    {
    //        // dictionary에 최소값으로 넣어줌
    //        var dict = new Dictionary<char, int>();
    //        for (int i = 0; i < keymap.Length; i++)
    //        {
    //            string keyStr = keymap[i];
    //            for (int k = 0; k < keyStr.Length; k++)
    //            {
    //                char c = keyStr[k];
    //                dict[c] = dict.TryGetValue(c, out var value) ? Math.Min(k, value) : k;
    //            }
    //        }

    //        // dictionary에서 검색 후 출력
    //        int[] answer = new int[targets.Length];
    //        for (int i = 0; i < targets.Length; i++)
    //        {
    //            string targetStr = targets[i];
    //            for (int k = 0; k < targetStr.Length; k++)
    //            {
    //                if (!dict.TryGetValue(targetStr[k], out int index))
    //                {
    //                    answer[i] = -1;
    //                    break;
    //                }

    //                answer[i] += index + 1;
    //            }
    //        }

    //        return answer;
    //    }
    //}
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            solution.solution("aukks", "wbqd", 5);
        }
    }


    public class Solution
    {
        public string solution(string s, string skip, int index)
        {

            string answer = "";
            string abc = "abcdefghijklmnopqrstuvwxyz";
            var abcList = abc.ToList();
            var sList = s.ToList();

            for (int j = 0; j < sList.Count; j++)
            {
                var newAbcList = abcList.Except(skip).ToList();
                var sFound = newAbcList.Find(x => x == sList[j]);
                var sFoundIdx = newAbcList.IndexOf(sFound);

                if (newAbcList.Count <= sFoundIdx + index)
                {
                    answer += newAbcList[(sFoundIdx + index) - newAbcList.Count];
                }
                else
                {
                    answer += newAbcList[sFoundIdx + index];
                }
            }
            return answer;
        }
    }
}

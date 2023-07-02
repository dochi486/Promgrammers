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
            solution.solution("zzzzzz", "abcdefghijklmnopqrstuvwxy", 6);
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
            
            var newAbcList = abcList.Except(skip).ToList();

            foreach (var t in sList)
            {
                var sFound = newAbcList.Find(x => x == t);
                var sFoundIdx = newAbcList.IndexOf(sFound);

                if (sFound > 0 && sFound != '\0')
                {
                    if (sFoundIdx + index >= newAbcList.Count)
                    {
                        int temp = sFoundIdx + index;

                        do
                        {
                            temp -= newAbcList.Count;
                        } while (temp >= newAbcList.Count);

                        answer += newAbcList[temp];
                    }
                    else
                    {
                        answer += newAbcList[sFoundIdx + index];
                    }
                }
            }
            return answer;
        }
    }
}

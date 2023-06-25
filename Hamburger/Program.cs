using System;
using System.Collections.Generic;

namespace Hamburger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            int[] ingredients = { 2, 1, 1, 2, 3, 1, 2, 3, 1 };
            solution.solution(ingredients);
        }
    }

    public class Solution
    {
        public int solution(int[] ingredient)
        {
            int answer = 0;
            bool isConsecutive = false;

            if (ingredient.Length < 4) 
                return 0;

            // ingredients 배열에서 1, 2, 3이 연속으로 있을 때만 포장을해서 answer의 카운트 증가시킨다.
            for (int i = 0; i < ingredient.Length - 1; i++)
            {
                // 두 수가 연속일 때
                if (isConsecutive)
                {
                    // 다시 한 번 더 검사
                    if (ingredient[i] + 1 == ingredient[i + 1])
                        answer++;
                }

                if (ingredient[i] + 1 == ingredient[i + 1])
                {
                    // 두 수는 연속된 수
                    isConsecutive = true;
                }
                else
                {
                    isConsecutive = false;
                }
            }

            return answer;
        }
    }
}

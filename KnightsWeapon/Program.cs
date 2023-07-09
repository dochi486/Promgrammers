using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsWeapon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            solution.solution(18, 3, 2);
        }
    }

    public class Solution
    {
        public int solution(int number, int limit, int power)
        {
            int answer = 0;
            List<int> divisorCount = new List<int>();
            List<int> knights = new List<int>();

            // 기사의 일련번호 number만큼의 기사수를 담는 컨테이너
            for (int i = 1; i <= number; i++)
            {
                knights.Add(i);
            }
            
            // 자신의 번호의 약수 개수에 해당하는 공격력을 가진 무기를 구매
            foreach (var t in knights)
            {
                var count = GetDivisors(t);
                divisorCount.Add(count);
            }

            // 공격력의 제한수치가 있고 제한수치보다 높은 공격력의 무기는 구매할 수 없음
            for (int i = 0; i < divisorCount.Count; i++)
            {
                if (divisorCount[i] > limit)
                    divisorCount[i] = power;

                answer += divisorCount[i];
            }
            // 무기의 공격력 1당 필요한 철은 1

            // 무기를 모두 만들기 위한 철의 무게 계산

            return answer;
        }

        public int GetDivisors(int number)
        {
            int count = 0;
            for (int i = 1; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;

                    if (number / i != i)
                        count++;
                }
            }
            return count;
        }
    }
    
}

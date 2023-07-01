using System;
using System.Collections.Generic;
using System.Linq;

namespace PE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            int[] lost = new int[] { 1, 2 };
            int[] reserve = new int[] { 2, 3 };
            solution.solution(3, lost, reserve);
        }
    }

    public class Solution
    {
        public int solution(int n, int[] lost, int[] reserve)
        {
            int answer = 0;

            if (n < 2 || n > 30)
                return 0;

            if (lost.Length > n)
                return 0;

            if (lost.Length < 1)
                return 0;

            // lost에는 중복되는 번호가 없다.
            var newLost = lost.Except(reserve).OrderBy(x => x).ToList();
            var newReserve = reserve.Except(lost).OrderBy(x => x).ToList();


            // reserve에 있는 번호만 사용 가능
            for (int j = 0; j < newLost.Count; j++)
            {

                if (newReserve.Contains(newLost[j] - 1))
                {
                    answer++;
                    newReserve.Remove(newLost[j] - 1);
                }
                else if (newReserve.Contains(newLost[j] + 1))
                {
                    answer++;
                    newReserve.Remove(newLost[j] + 1);
                }
            }

            answer = n - (newLost.Count - answer);

            return answer;
        }
    }


    //public class Solution
    //{
    //    public int solution(int n, int[] lost, int[] reserve)
    //    {
    //        int answer = 0;

    //        if (n < 2 || n > 30)
    //            return 0;

    //        if (lost.Length > n)
    //            return 0;

    //        if (lost.Length < 1)
    //            return 0;

    //        var lostExcept = lost.Distinct();
    //        var newLost = lostExcept.ToList();

    //        var newReserve = reserve.ToList();

    //        // reserve에 있는 번호만 사용 가능
    //        for (int i = 0; i < newReserve.Count; i++)
    //        {
    //            if (newLost.Count == 0)
    //                break;

    //            foreach (var t in newLost)
    //            {
    //                if (newReserve.Count == 0)
    //                    break;

    //                if (newLost.Contains(newReserve[i]))
    //                {
    //                    continue;
    //                }

    //                if (newReserve.Contains(t + 1))
    //                {
    //                    answer++;
    //                    newReserve.Remove(t + 1);
    //                }
    //                else if (newReserve.Contains(t - 1))
    //                {
    //                    answer++;
    //                    newReserve.Remove(t - 1);
    //                }
    //            }
    //        }

    //        answer = n - (newLost.Count - answer);

    //        return answer;
    //    }
    //}
}

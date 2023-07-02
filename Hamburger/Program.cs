using System;
using System.Collections.Generic;
using System.Linq;

namespace Hamburger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            int[] ingredients = { 1, 3, 2, 4, 1 ,2};
            solution.solution(ingredients);
        }
    }

    public class Solution
    {
        public int solution(int[] ingredients)
        {
            int answer = 0;

            var isBread       = false;
            var isLettuce     = false;
            var isPatty       = false;
            var isTopBread    = false;
            var firstBreadIdx = 0;

            var newIngredients = ingredients.ToList();

            foreach (var item in ingredients)
            {
                for (int i = 1; i <= newIngredients.Count - 1; i++)
                {
                    if (newIngredients[0] == 1)
                        isBread = true;
                    else if (newIngredients[0] == 2)
                        isLettuce = true;
                    else if (newIngredients[0] == 3)
                        isPatty = true;

                    // 1, 2, 3, 1 이 연속으로 있으면
                    switch (newIngredients[i])
                    {
                        case 1:
                            if (newIngredients[i - 1] == 3)
                            {
                                isTopBread = true;
                            }
                            else
                            {
                                isBread = true;
                                firstBreadIdx = i;
                            }
                            break;
                        case 2:
                            if (newIngredients[i - 1] == 1)
                            {
                                isLettuce = true;
                            }
                            break;
                        case 3:
                            if (newIngredients[i - 1] == 2)
                            {
                                isPatty = true;
                            }
                            break;
                    }
                }

                if (isBread && isLettuce && isPatty && isTopBread)
                {
                    answer++;
                    isBread = false;
                    isLettuce = false;
                    isPatty = false;
                    isTopBread = false;

                    if(newIngredients.Count > 4)
                        newIngredients.RemoveRange(firstBreadIdx, 4);
                }
            }
            return answer;
        }

        //public int solution(int[] ingredient)
        //{
        //    int answer = 0;
        //    bool isConsecutive = false;

        //    if (ingredient.Length < 4) 
        //        return 0;

        //    // ingredients 배열에서 1, 2, 3이 연속으로 있을 때만 포장을해서 answer의 카운트 증가시킨다.
        //    for (int i = 0; i < ingredient.Length - 1; i++)
        //    {
        //        // 두 수가 연속일 때
        //        if (isConsecutive)
        //        {
        //            // 다시 한 번 더 검사
        //            if (ingredient[i] + 1 == ingredient[i + 1])
        //                answer++;
        //        }

        //        if (ingredient[i] + 1 == ingredient[i + 1])
        //        {
        //            // 두 수는 연속된 수
        //            isConsecutive = true;
        //        }
        //        else
        //        {
        //            isConsecutive = false;
        //        }
        //    }

        //    return answer;
        //}
    }
}

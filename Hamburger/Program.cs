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
            int[] ingredients = { 1, 1, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1 };
            solution.solution(ingredients);
        }
    }

    public class Solution
    {
        //{
        //    public static readonly int BREAD = 1;
        //    public static readonly int VEGETABLE = 2;
        //    public static readonly int MEAT = 3;

        //    public int solution(int[] ingredient)
        //    {
        //        if (ingredient.Length < 4) return 0;

        //        var ingredients = ingredient.ToList();

        //        int answer = 0;
        //        for (int i = 0; i + 3 < ingredients.Count; i++)
        //        {
        //            if (ingredients[i] == BREAD
        //                && ingredients[i + 1] == VEGETABLE
        //                && ingredients[i + 2] == MEAT
        //                && ingredients[i + 3] == BREAD)
        //            {
        //                answer++;
        //                for (int j = 0; j < 4; j++)
        //                {
        //                    ingredients.RemoveAt(i);
        //                }
        //                i = Math.Max(i - 4, -1);
        //            }
        //        }
        //        return answer;
        //    }
        //}


        //public int solution(int[] ingredients)
        //{
        //    int answer = 0;

        //    Stack<int> newIngredients = new Stack<int>();

        //    // 인자로 받은 ingredients를 스택에 복사하고
        //    foreach (var ingredient in ingredients)
        //    {
        //        newIngredients.Push(ingredient);
        //    }

        //    int[] ingredientOrder = new int[] { 1, 2,3, 1 };
        //    Stack<int> ingredientStack = new Stack<int>(ingredientOrder);
        //    Stack<int> cloneIngredientStack = new Stack<int>();
        //    Stack<int> hamburgerStack = new Stack<int>();

        //    Stack<int> leftIngredients = new Stack<int>();

        //    do
        //    {
        //        // newIngredient 스택의 맨위 원소를 확인해서 
        //        // 햄버거재료 스택의 맨위 원소와 같다면
        //        // newIngredient의 원소를 팝해서 햄버거스택에 쌓는다. 
        //        if (ingredientStack.Count == 0)
        //        {
        //            if (newIngredients.Peek() == cloneIngredientStack.Peek())
        //            {
        //                hamburgerStack.Push(newIngredients.Peek());
        //                newIngredients.Pop();
        //            }
        //            else
        //            {
        //                // 같지 않다면 팝해서 다른 스택 하나에 또 쌓아둔다.
        //                leftIngredients.Push(newIngredients.Pop());
        //            }
        //        }
        //        else
        //        {
        //            if (newIngredients.Peek() == ingredientStack.Peek())
        //            {
        //                hamburgerStack.Push(newIngredients.Peek());
        //                newIngredients.Pop();
        //            }
        //            else
        //            {
        //                // 같지 않다면 팝해서 다른 스택 하나에 또 쌓아둔다.
        //                leftIngredients.Push(newIngredients.Pop());
        //            }
        //            // newIngredient의 원소 카운트가 양수일동안 반복
        //            cloneIngredientStack.Push(ingredientStack.Pop());
        //        }

        //    } while (newIngredients.Count > 0);

        //    do
        //    {
        //        if (ingredientStack.Count == 0)
        //        {
        //            if (leftIngredients.Peek() == cloneIngredientStack.Peek())
        //            {
        //                hamburgerStack.Push(leftIngredients.Peek());
        //                leftIngredients.Pop();
        //            }
        //            else
        //            {
        //                // 같지 않다면 팝해서 다른 스택 하나에 또 쌓아둔다.
        //                newIngredients.Push(leftIngredients.Pop());
        //            }
        //        }
        //        else
        //        {
        //            if (leftIngredients.Peek() == ingredientStack.Peek())
        //            {
        //                hamburgerStack.Push(leftIngredients.Peek());
        //                leftIngredients.Pop();
        //            }
        //            else
        //            {
        //                // 같지 않다면 팝해서 다른 스택 하나에 또 쌓아둔다.
        //                newIngredients.Push(leftIngredients.Pop());
        //            }
        //            // newIngredient의 원소 카운트가 양수일 동안 반복
        //            ingredientStack.Push(cloneIngredientStack.Pop());
        //        }

        //    } while (leftIngredients.Count > 0);


        //    answer = hamburgerStack.Count / 4;

        //    return answer;
        //}

        public int solution(int[] ingredients)
        {
            int answer = 0;

            var firstBreadIdx = 0;

            var newIngredients = ingredients.ToList();

            for (int i = 0; i + 3 < newIngredients.Count; i++)
            {

                // 1, 2, 3, 1 이 연속으로 있으면
                //switch (newIngredients[i])
                //{
                //    case 1:
                //        if (newIngredients[i - 1] == 3)
                //        {
                //            isTopBread = true;
                //        }
                //        else
                //        {
                //            isBread = true;
                //            firstBreadIdx = i;
                //        }

                //        break;
                //    case 2:
                //        if (newIngredients[i - 1] == 1)
                //        {
                //            isLettuce = true;
                //        }

                //        break;
                //    case 3:
                //        if (newIngredients[i - 1] == 2)
                //        {
                //            isPatty = true;
                //        }

                //        break;
                //}

                if (newIngredients[i] == 1 && newIngredients[i + 1] == 2 && newIngredients[i + 2] == 3 && newIngredients[i + 3] == 1)
                {
                    answer++;
                    firstBreadIdx = i;
                    // firstBreadIdx로부터 4 범위 값이 있는지 확인해야함
                    newIngredients.RemoveRange(firstBreadIdx, 4);
                    i = -1;
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
    }
}



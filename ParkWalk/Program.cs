using System;
using System.Linq;
using System.Collections.Generic;

namespace ParkWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            string[] park = { "OSO", "OOO", "OXO", "OOO" };
            string[] routes = { "E 2", "S 3", "W 1" };
            solution.solution(park, routes);
        }
    }

    public class Solution
    {
        public int[] solution(string[] park, string[] routes)
        {
            List<int> answer = new List<int>();

            int height = park.Length;
            int width = park[0].Length;

            int startY = 0;
            int startX = 0;

            string[,] parkBoard = new string[height,width];

            // park는 직사각형.. 
            // 보드의 높이는 park배열의 요소 수와 같음

            // park 배열을 먼저 보드로 만들어 놓고
            int tempLength = park.Length;
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    parkBoard[i, j] = park[i][j].ToString();
                    if(park[i][j] == 'S')
                    {
                        startY = i;
                        startX = j;
                    }
                }
            }

            // park 판에서 
            // S는 시작점
            // O는 움직일 수 있는 지점
            // X는 장애물이라 갈 수 없는 지점

            // route만큼 움직이는 로봇 강아지
            // E = x + n
            // W = x - n
            // N = y - n
            // S = y + n

            // board에서 S를 찾고 어떤 좌표에 있는지 확인한 다음
            // parkBoard[startX, startY]가 시작점

            int toMove = 0;
            // 해당 좌표에서부터 routeMap의 내용을 루프 돌면서
            foreach (var item in routes)
            {
                // 해당 방향으로 이동할 수 있는지 확인하고
                var route = item.Split(' ');
                int move = int.Parse(route[1]);
                // 갈 수 있으면 좌표를 바꿔준다.
                switch (route[0])
                {
                    case "E":
                        {
                            // 도착 지점이 공원을 벗어나는지 확인
                            if (startX + move > width - 1)
                                continue;

                            // 가는 길에 장애물을 마주치는지 확인
                            do
                            {
                                if (parkBoard[startY, startX + toMove] != "X")
                                    toMove++;
                                else
                                {
                                    toMove = 0;
                                    break;
                                }
                            } while (toMove < move);

                            if (toMove == 0)
                                continue;

                            if (parkBoard[startY, startX + move] != "X" || parkBoard[startY, startX + move] != "S")
                            {
                                startX += move;
                            }
                            break;  
                        }

                    case "W":
                        {
                            if (startX - move > width - 1)
                                continue;

                            // 가는 길에 장애물을 마주치는지 확인
                            do
                            {
                                if (parkBoard[startY, startX - toMove] != "X")
                                    toMove--;
                                else
                                {
                                    toMove = 0;
                                    break;
                                }
                            } while (toMove > move);

                            if (toMove == 0)
                                continue;

                            if (parkBoard[startY, startX - move] != "X" || parkBoard[startY, startX - move] != "S")
                            {
                                startX -= move;
                            }
                            break;
                        }

                    case "N":
                        {
                            if (startY - move > height - 1)
                                continue;

                            // 가는 길에 장애물을 마주치는지 확인
                            do
                            {
                                if (parkBoard[startY - toMove, startX] != "X")
                                    toMove--;
                                else
                                {
                                    toMove = 0;
                                    break;
                                }
                            } while (toMove > move);

                            if (toMove == 0)
                                continue;

                            if (parkBoard[startY - move, startX] != "X" || parkBoard[startY - move, startX] != "S")
                            {
                                startY -= move;
                            }
                            break;
                        }

                    case "S":
                        {
                            if (startY + move > height - 1)
                                continue;

                            // 가는 길에 장애물을 마주치는지 확인
                            do
                            {
                                if (parkBoard[startY + toMove, startX] != "X")
                                    toMove++;
                                else
                                {
                                    toMove = 0;
                                    break;
                                }
                            } while (toMove < move);

                            if (toMove == 0)
                                continue;

                            if (parkBoard[startY + move, startX] != "X" || parkBoard[startY + move, startX] != "S")
                            {
                                startY += move;
                            }
                            break;
                        }

                }
            }
            answer.Add(startY);
            answer.Add(startX);

            return answer.ToArray();
        }
    }
}

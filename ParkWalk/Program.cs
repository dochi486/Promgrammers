using System;
using System.Collections.Generic;

namespace ParkWalk
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            string[] park = {"OOO", "OOO", "OXS", "OOO", "OOO", "OOO", "OOO"};
            string[] routes = {"S 1", "S 3", "E 1", "W 2", "N 3", "S 3", "W 1"};
            solution.solution(park, routes);
        }
    }

    public class Solution
    {
        public int[] solution(string[] park, string[] routes)
        {
            var answer = new List<int>();

            var height = park.Length;
            var width = park[0].Length;

            var startH = 0;
            var startW = 0;

            var parkBoard = new string[height, width];

            // park는 직사각형.. 
            // 보드의 높이는 park배열의 요소 수와 같음

            // park 배열을 먼저 보드로 만들어 놓고
            for (var h = 0; h < width; h++)
            for (var w = 0; w < height; w++)
            {
                parkBoard[w, h] = park[w][h].ToString();
                if (park[w][h] == 'S')
                {
                    startH = w;
                    startW = h;
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
            // parkBoard[startH, startW] = 시작점.. 

            // 해당 좌표에서부터 routeMap의 내용을 루프 돌면서
            foreach (var item in routes)
            {
                var toMove = 0;
                var route = item.Split(' ');
                var move = int.Parse(route[1]);

                // 해당 방향으로 이동할 수 있는지 확인하고
                // 갈 수 있으면 좌표를 바꿔준다.
                switch (route[0])
                {
                    case "E":
                    {
                        // 도착 지점이 공원을 벗어나는지 확인
                        if (startW + move > width - 1)
                            continue;

                        // 가는 길에 장애물을 마주치는지 확인
                        do
                        {
                            if (parkBoard[startH, startW + toMove] != "X")
                            {
                                toMove++;
                            }
                            else
                            {
                                toMove = 0;
                                break;
                            }
                        } while (toMove < move);

                        if (toMove == 0)
                            continue;

                        if (parkBoard[startH, startW + move] != "X") startW += move;
                        break;
                    }

                    case "W":
                    {
                        if (startW - move > width - 1 || startW - move < 0)
                            continue;

                        // 가는 길에 장애물을 마주치는지 확인
                        do
                        {
                            if (parkBoard[startH, startW - toMove] != "X")
                            {
                                toMove++;
                            }
                            else
                            {
                                toMove = 0;
                                break;
                            }
                        } while (toMove < move);

                        if (toMove == 0)
                            continue;


                        if (parkBoard[startH, startW - move] != "X") startW -= move;
                        break;
                    }

                    case "N":
                    {
                        if (startH - move > height - 1 || startH - move < 0)
                            continue;

                        // 가는 길에 장애물을 마주치는지 확인
                        do
                        {
                            if (parkBoard[startH - toMove, startW] != "X")
                            {
                                toMove++;
                            }
                            else
                            {
                                toMove = 0;
                                break;
                            }
                        } while (toMove < move);

                        if (toMove == 0)
                            continue;

                        if (parkBoard[startH - move, startW] != "X") startH -= move;
                        break;
                    }

                    case "S":
                    {
                        if (startH + move > height - 1)
                            continue;

                        // 가는 길에 장애물을 마주치는지 확인
                        do
                        {
                            if (parkBoard[startH + toMove, startW] != "X")
                            {
                                toMove++;
                            }
                            else
                            {
                                toMove = 0;
                                break;
                            }
                        } while (toMove < move);

                        if (toMove == 0)
                            continue;

                        if (parkBoard[startH + move, startW] != "X") startH += move;
                        break;
                    }
                }
            }

            answer.Add(startH);
            answer.Add(startW);

            return answer.ToArray();
        }
    }
}
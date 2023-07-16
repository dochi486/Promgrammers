using System;

namespace _2016
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var solution = new Solution();
            solution.solution(9, 21); //수요일
        }
    }

    public class Solution
    {
        public string solution(int a, int b)
        {
            //List<string> days = new List<string>();
            //days.Add("SUN");
            //days.Add("MON");
            //days.Add("TUE");
            //days.Add("WED");
            //days.Add("THU");
            //days.Add("FRI");
            //days.Add("SAT");

            // b % 7 == 0 ? b % 7 : (b % 7) - 1
            //var dayString = days[b % 2];

            var dateTime = new DateTime(2016, a, b);
            var day = dateTime.DayOfWeek;
            var dayString = "";

            switch (day)
            {
                case DayOfWeek.Sunday:
                    dayString = "SUN";
                    break;
                case DayOfWeek.Monday:
                    dayString = "MON";

                    break;
                case DayOfWeek.Tuesday:
                    dayString = "TUE";

                    break;
                case DayOfWeek.Wednesday:
                    dayString = "WED";

                    break;
                case DayOfWeek.Thursday:
                    dayString = "THU";

                    break;
                case DayOfWeek.Friday:
                    dayString = "FRI";

                    break;
                case DayOfWeek.Saturday:
                    dayString = "SAT";

                    break;
            }

            return dayString;
        }
    }
}
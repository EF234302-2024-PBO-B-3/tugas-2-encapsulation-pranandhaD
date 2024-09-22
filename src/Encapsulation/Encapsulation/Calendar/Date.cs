using System;

namespace Encapsulation.Calendar
{
    public class Date
    {
        public int Month { get; }
        public int Day { get; }
        public int Year { get; }

        public Date(int month, int day, int year)
        {
            if (IsValidDate(month, day, year))
            {
                Month = month;
                Day = day;
                Year = year;
            }
            else
            {
                Month = 1;
                Day = 1;
                Year = 1970;
            }
        }

        private static bool IsValidDate(int month, int day, int year)
        {
            return DateTime.TryParse($"{year}-{month}-{day}", out _);
        }

        public void DisplayDate()
        {
            Console.WriteLine($"{Month}/{Day}/{Year}");
        }
    }
}
using System;
using System.Collections.Generic;

namespace euler.solutions
{
    public class Problem019
    {
        public static void Run()
        {
            Timer.RecordMiliseconds(() =>
            {
                var day = new CalendarDay(DayOfWeek.Monday, 1900, Month.January, 1);
                int sundayCount = 0;
                do
                {
                    if (day.DayOfWeek == DayOfWeek.Sunday)
                        sundayCount++;
                    day = day.NextDay();
                } while (day.Year < 2001);


                Console.WriteLine("The 20th century had {0} sundays", sundayCount);
            });
        }
    }

    public class CalendarDay
    {
        public CalendarDay(DayOfWeek dayOfWeek, int year, Month month, int dayOfMonth)
        {
            DayOfWeek = dayOfWeek;
            Year = year;
            Month = month;
            DayOfMonth = dayOfMonth;
        }

        public int Year { get; private set; }
        public Month Month { get; private set; }
        public int DayOfMonth { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }

        public bool IsOnLastDayOfMonth()
        {
            throw new NotImplementedException();
        }

        public CalendarDay NextDay()
        {
            DayOfWeek nextDayOfWeek;
            int nextYear;
            Month nextMonth;
            int nextDayOfMonth;

            bool isLastDayOfMonth = DayOfMonth == DaysInMonth();
            if (!isLastDayOfMonth)
            {
                nextDayOfMonth = DayOfMonth + 1;
                nextMonth = Month;
                nextYear = Year;
            }
            else
            {
                nextDayOfMonth = 1;
                bool isLastMonthOfYear = Month == Month.December;
                if (!isLastMonthOfYear)
                {
                    nextMonth =Month+1;
                    nextYear = Year; 
                }
                else
                {
                    nextMonth = Month.January;
                    nextYear = Year + 1;
                }
            }

            bool isLastDayOfWeek = DayOfWeek == DayOfWeek.Saturday;
            if (!isLastDayOfWeek)
                nextDayOfWeek = DayOfWeek + 1;
            else
                nextDayOfWeek = DayOfWeek.Sunday;

            return new CalendarDay(nextDayOfWeek, nextYear, nextMonth, nextDayOfMonth);
        }

        private int DaysInMonth()
        {
            var daysInMonth = new Dictionary<Month, Func<int>>
            {
                {Month.January, () => 31},
                {Month.February, () => DaysInFebruary(Year)},
                {Month.March, () => 31},
                {Month.April, () => 30},
                {Month.May, () => 31},
                {Month.June, () => 30},
                {Month.July, () => 31},
                {Month.August, () => 31},
                {Month.September, () => 30},
                {Month.October, () => 31},
                {Month.November, () => 30},
                {Month.December, () => 31},
            };
            return daysInMonth[Month]();
        }

        private static int DaysInFebruary(int year)
        {
            return IsLeapYear(year)
                ? 29
                : 28;
        }

        private static bool IsLeapYear(int year)
        {
            bool isCentury = year%100 == 0;
            if (isCentury)
            {
                bool isDivisibleByFourHundred = year%400 == 0;
                return isDivisibleByFourHundred;
            }

            bool isDivisibleByFour = year%4 == 0;
            return isDivisibleByFour;
        }
    }

    public class CalendarDayGenerator
    {
        private readonly CalendarDay _firstDayToGenerate;
        private CalendarDay _previousDay;

        public CalendarDayGenerator(CalendarDay firstDayToGenerate)
        {
            _firstDayToGenerate = firstDayToGenerate;
        }
    }

    public enum DayOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thrusday,
        Friday,
        Saturday
    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
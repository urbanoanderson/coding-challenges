/*
    Source: https://github.com/chesman12/booking-hotel

    Solution Author: Anderson Urbano
*/

using System;
using System.Linq;
using System.Globalization;

namespace Challenges.BookingHotel
{
    public enum ClientType
    {
        Regular,
        Rewards,
    }

    public class Hotel
    {
        public string Name { get; set; }

        public int Classification { get; set; }

        public int WeekPriceRegular { get; set; }

        public int WeekPriceReward { get; set; }

        public int WeekendPriceRegular { get; set; }

        public int WeekendPriceReward { get; set; }
    }

    public class BookingHotel
    {
        private static Hotel[] hotels = new Hotel[]
        {
            new Hotel() { Name = "Lakewood", Classification = 3, WeekPriceRegular = 110, WeekPriceReward = 80, WeekendPriceRegular = 90, WeekendPriceReward = 80 },
            new Hotel() { Name = "Bridgewood", Classification = 4, WeekPriceRegular = 160, WeekPriceReward = 110, WeekendPriceRegular = 60, WeekendPriceReward = 50 },
            new Hotel() { Name = "Ridgewood", Classification = 5, WeekPriceRegular = 220, WeekPriceReward = 100, WeekendPriceRegular = 150, WeekendPriceReward = 40 },
        };

        public static string Solution(string input)
        {
            var split = input.Replace(" ", string.Empty).Split(":");
            ClientType clientType = (ClientType) Enum.Parse(typeof(ClientType), split[0]);
            string[] datesStr = split[1].Split(",");
            DateTime[] dates = datesStr.Select(x => StringToDateTime(x)).ToArray();

            Hotel result = Solution(clientType, dates);
            return result.Name;
        }

        public static Hotel Solution(ClientType clientType, DateTime[] dates)
        {
            Hotel result = null;
            int minCost = int.MaxValue;

            foreach (Hotel hotel in hotels)
            {
                int cost = 0;

                foreach (var date in dates)
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        cost += clientType == ClientType.Regular ? hotel.WeekendPriceRegular : hotel.WeekendPriceReward;
                    else
                        cost += clientType == ClientType.Regular ? hotel.WeekPriceRegular : hotel.WeekPriceReward;
                }

                if (cost < minCost || (cost == minCost && hotel.Classification > result.Classification))
                {
                    result = hotel;
                    minCost = cost;
                }
            }

            return result;
        }

        private static DateTime StringToDateTime(string input)
        {
            return DateTime.ParseExact(input.Substring(0, 9), "ddMMMyyyy", CultureInfo.InvariantCulture);
        }
    }
}

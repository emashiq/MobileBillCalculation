using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        static Tuple<TimeSpan, TimeSpan> peakHour = new Tuple<TimeSpan, TimeSpan>(new TimeSpan(9, 0, 0), new TimeSpan(22, 59, 59));
        static Tuple<TimeSpan, TimeSpan> offPeakHourItem1 = new Tuple<TimeSpan, TimeSpan>(new TimeSpan(23, 0, 0), new TimeSpan(23, 59, 59));
        static Tuple<TimeSpan, TimeSpan> offPeakHourItem2 = new Tuple<TimeSpan, TimeSpan>(new TimeSpan(0, 0, 0), new TimeSpan(8, 59, 59));
        static double pickHourPrice = 0.30D;
        static double offPickHourPrice = 0.20D;
        static int pulse = 21;
        
        static void Main(string[] args)
        {
            CalculatePrice();
            Console.ReadKey();
        }
        
        static void CalculatePrice()
        {
            var startTime = DateTime.Parse(Console.ReadLine());
            var endTime = DateTime.Parse(Console.ReadLine());
            double totalAmount = 0D;
            do
            {
                startTime = startTime.AddSeconds(pulse);
                var startTimeAsString  = startTime.ToString("HH:mm:ss");
                var startTimeArray = startTimeAsString.Split(':').Select(c=>Int32.Parse(c)).ToArray();
                var startTimeTimeSpan = new TimeSpan(startTimeArray[0], startTimeArray[1], startTimeArray[2]);
                if (startTimeTimeSpan >= offPeakHourItem2.Item1 && startTimeTimeSpan <= offPeakHourItem2.Item2)
                {
                    totalAmount += offPickHourPrice;
                }
                else if (startTimeTimeSpan >= offPeakHourItem1.Item1 && startTimeTimeSpan <= offPeakHourItem1.Item2)
                {
                    totalAmount += offPickHourPrice;
                }
                else if (startTimeTimeSpan >= peakHour.Item1 && startTimeTimeSpan <= peakHour.Item2)
                {
                    totalAmount += pickHourPrice;
                }
               
            } while (startTime<endTime);
            Console.WriteLine(totalAmount.ToString());
        }

    }
}

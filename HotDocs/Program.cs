using HotDocs.Enums;
using System;
using System.Collections.Generic;

namespace HotDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            List <StayDuration> list = new List<StayDuration>();

            list.Add( new StayDuration(StayType.ShortStay, new DateTime(2017, 09, 07, 5, 0, 0), new DateTime(2017, 09, 07, 7, 0, 0)));
            list.Add(new StayDuration(StayType.ShortStay, new DateTime(2017, 09, 07, 5, 0, 0), new DateTime(2017, 09, 07, 16, 0, 0)));
            list.Add(new StayDuration(StayType.ShortStay, new DateTime(2017, 09, 07, 16, 0, 0), new DateTime(2017, 09, 09, 19, 0, 0)));
            list.Add(new StayDuration(StayType.LongStay, new DateTime(2017, 09, 07, 16, 0, 0), new DateTime(2017, 09, 07, 21, 0, 0)));
            list.Add(new StayDuration(StayType.LongStay, new DateTime(2017, 09, 07, 7, 0, 0), new DateTime(2017, 09, 09, 5, 0, 0)));

            foreach (var duration in list)
            {
                duration.PrintResult();
            }

            Console.WriteLine("Press any key to exit!");
            Console.Read();
        }
    }
}
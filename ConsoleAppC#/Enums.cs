using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCS
{
    internal class Enums
    {
        public Enums() { }

        public static void currentSeason()
        {
            Season currentSeason = (Season)2;
            Console.WriteLine(currentSeason);

            DaysOfWeek day = (DaysOfWeek)3;
            Console.WriteLine(day); // Outputs: Wednesday

            bool isValid = Enum.IsDefined(typeof(DaysOfWeek), 3);
            Console.WriteLine(isValid); // Outputs: True


        }
    }
    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
    enum DaysOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    enum ErrorCode : ushort
    {
        None = 0,
        Unknown = 1,
        ConnectionLost = 100,
        OutlierReading = 200
    }
}

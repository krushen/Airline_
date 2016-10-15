using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMVP
{
    public enum FlightStatus
    {
        CheckIn = 1,
        GateClosed = 2,
        Arrived = 3,
        DeparturedAt = 4,
        Unknown = 5,
        Canceled = 6,
        ExpectedAt = 7,
        Delayed = 8,
        InFlight = 9,
        Gate = 10,
        Boarding = 11
    }

    public class FlightCompareByDateTime : IComparer<Flight>
    {
        public int Compare(Flight x, Flight y)
        {
            if (x.At.Hour > y.At.Hour) return 1;
            else if (x.At.Hour < y.At.Hour) return -1;
            if (x.At.Hour == y.At.Hour)
                if (x.At.Minute > y.At.Minute) return 1;
                else if (x.At.Minute < y.At.Minute) return -1;
            return 0;

        }
    }
    public class Flight : IFlighter, IComparable
    {
        public DateTime At { get; set; }
        public int Number { get; set; }
        public string CityA { get; set; }
        public string CityB { get; set; }
        public string AirLine { get; set; }
        public string Terminal { get; set; }
        public FlightStatus Status { get; set; }
        public Passenger[] Passengers = new Passenger[10];
        public override string ToString()
        {
            string statusString = Status.ToString();
            if (At.Minute < 50)
            {
                DateTime atStatus = new DateTime(At.Year, At.Month, At.Day, At.Hour, At.Minute + 10, At.Second);
                statusString += " " + atStatus.Hour + ":" + atStatus.Minute + " ";
            }
            else
            {
                DateTime atStatus = new DateTime(At.Year, At.Month, At.Day, At.Hour, At.Minute, At.Second);
                statusString += " " + atStatus.Hour + ":" + atStatus.Minute + " ";
            }
            if ((Status == FlightStatus.DeparturedAt) || (Status == FlightStatus.ExpectedAt))
                return string.Format("    {0,-20} {6,-10} {1,-15} {2,-15} {3,-10} {4,-35} {5,-22} ", At, CityA, CityB, Terminal, AirLine, statusString, Number);
            else
                return string.Format("    {0,-20} {6,-10} {1,-15} {2,-15} {3,-10} {4,-35} {5,-22} ", At, CityA, CityB, Terminal, AirLine, Status, Number);

        }

        public Flight()
        {
            At = DateTime.Now;
            Number = 0;
            CityA = "";
            CityB = "";
            AirLine = "";
            Terminal = "";
            Status = FlightStatus.Unknown;
            Passengers = new Passenger[5];
        }

        public void PrintHeaderTop(bool duration)
        {
            if (duration)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("ARRIVALS");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("DEPARTURES");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("    Time:                Flight:    From:           To:          Terminal:     Airline:                            Status: ");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintStringInColor()
        {
            switch (Status)
            {
                case FlightStatus.CheckIn:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case FlightStatus.GateClosed:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case FlightStatus.Arrived:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case FlightStatus.DeparturedAt:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case FlightStatus.Unknown:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case FlightStatus.Canceled:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case FlightStatus.ExpectedAt:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case FlightStatus.Delayed:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case FlightStatus.InFlight:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case FlightStatus.Gate:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case FlightStatus.Boarding:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    break;
            }
            Console.WriteLine(ToString());
            Console.BackgroundColor = ConsoleColor.Black;

        }

        public int CompareTo(object flight)
        {
            return Number.CompareTo(((Flight)flight).Number);
        }


    }
}

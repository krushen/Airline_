using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelMVP;
namespace ViewMVP
{
    public class ConsolePrint
    {
        public string CityHome { get; set; }

        public ConsolePrint(string CityHome)
        {
            this.CityHome = CityHome;
        }
        public ConsolePrint()
        {

        }
        public void PrintInfo(Jobs taskMode, Flight[] flightArray)
        {
            Flight tempFlight = new Flight();
            Passenger tempPassenger = new Passenger();
            if (taskMode == Jobs.InformationNotFound)
            {
                Console.WriteLine("Information wasn't finding!");
                Console.WriteLine();
            }
            if ((taskMode == Jobs.DoPrintFlightsOnlyInfo) || (taskMode == Jobs.DoPrintFlightsAllInfo))
            {
                bool isDuration = true;
                bool isFlight = false;
                bool isHeader = true;
                for (int i = 0; i <= 1; i++)
                {
                    isHeader = false;
                    foreach (var flight in flightArray)
                    {
                        isFlight = false;
                        if (isDuration) if (flight.CityB == CityHome)
                            {
                                if (!isHeader)
                                {
                                    tempFlight.PrintHeaderTop(isDuration);
                                    tempFlight.PrintHeader();
                                    isHeader = true;
                                }
                                flight.PrintStringInColor(); isFlight = true;
                            }
                        if (!isDuration) if (flight.CityA == CityHome)
                            {
                                if (!isHeader)
                                {
                                    tempFlight.PrintHeaderTop(isDuration);
                                    tempFlight.PrintHeader();
                                    isHeader = true;
                                }
                                flight.PrintStringInColor(); isFlight = true;
                            }

                        if ((taskMode == Jobs.DoPrintFlightsAllInfo) && (isFlight))
                        {
                            bool isFirst = true;
                            for (int j = 0; j < flight.Passengers.Length; j++)
                            {
                                if (flight.Passengers[j] != null)
                                {
                                    if (isFirst) { tempPassenger.PrintHeader(); isFirst = false; }
                                    Console.WriteLine(flight.Passengers[j].ToString());
                                }
                            }
                        }
                    }
                    isDuration = false;
                }
            }
            if (taskMode == Jobs.DoPrintPassengersInfo)
            {
                tempFlight.PrintStringInColor();
                bool isFirst = true;
                for (int j = 0; j < flightArray[0].Passengers.Length; j++)
                {
                    if (flightArray[0].Passengers[j] != null)
                    {
                        if (isFirst) { tempPassenger.PrintHeader(); isFirst = false; }
                        Console.WriteLine(flightArray[0].Passengers[j].ToString());
                    }
                }
            }
            if (taskMode == Jobs.DoPrintFlightInfo)
            {
                tempFlight.PrintHeader();
                flightArray[0].PrintStringInColor();
            }
            Console.WriteLine();
        }
    }
}

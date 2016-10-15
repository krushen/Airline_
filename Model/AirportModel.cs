using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMVP
{
   
    public class AirportModel:IAirportModel
    {
        List<Flight> flightList;
        const string _cityHome = "Kyiv";
        public string CityHome => _cityHome;
      
        public IEnumerable<Flight> Flights => flightList;
        internal AirportModel()
        {
            flightList = new List<Flight>
        #region flightList
         {
             new Flight(){
                    At = new DateTime(2016, 07, 23, 23, 50, 0),
                    Number=1652,
                    CityA = "Paris",
                    CityB = _cityHome,
                    AirLine = "Air France",
                    Terminal ="B",
                    Status = FlightStatus.Arrived,
                    Passengers = new Passenger[] {
                        new Passenger("Dmytro", "Solodovnik", "Ukrainian", "MT1234", new DateTime(1988, 9, 7), Sex.Male, 450.00, TicketClass.Economy),
                        new Passenger("June", "Marime", "France", "FR1234", new DateTime(1966, 8, 14), Sex.Female, 700.00, TicketClass.Business),
                        new Passenger("Magdalena", "Zukovska", "Poles", "PO1234", new DateTime(1996, 8, 6), Sex.Female, 440.00, TicketClass.Economy),}
                            },
               new Flight(){
                    At = new DateTime(2016, 07, 23, 05, 45, 0),
                    Number=9594,
                    CityA = "Frankfurt",
                    CityB = _cityHome,
                    AirLine = "Air Canada",
                    Terminal ="D",
                    Status = FlightStatus.Arrived,
                     Passengers = new Passenger[] {
                        new Passenger("Taras", "Kylia", "Ukrainian", "MS3333", new DateTime(1956, 1, 1), Sex.Male, 800.00, TicketClass.Business),
                        new Passenger("Mykola", "Poroshenko", "Ukrainian", "MU1111", new DateTime(1986, 7, 7), Sex.Male, 840.00, TicketClass.Business),
                        new Passenger("Ivan", "Polozov", "Ukrainian", "MI4444", new DateTime(1966, 8, 4), Sex.Male, 400.00, TicketClass.Economy),
                            },
                },
               new Flight(){
                    At = new DateTime(2016, 07, 23, 05, 15, 0),
                    Number=1387,
                    CityA = "Tallinn",
                    CityB = _cityHome,
                    AirLine = "Adria Airways",
                    Terminal ="D",
                    Status = FlightStatus.Arrived,
                },
                 new Flight(){
                    At = new DateTime(2016, 07, 23, 05, 45, 0),
                    Number=114,
                    CityA = "London/LGW",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="D",
                    Status = FlightStatus.ExpectedAt,
                     Passengers = new Passenger[] {
                        new Passenger("Fritz", "Hofman", "Germans", "Ge1234", new DateTime(1977, 11, 5), Sex.Male, 770.00, TicketClass.Business),
                        new Passenger("Ivanis", "Urmalis", "Estonian", "ES9999", new DateTime(1999, 9, 9), Sex.Male, 400.00, TicketClass.Economy),
                        new Passenger("Ivana", "Mikylenko", "Ukrainian", "MU4444", new DateTime(1988, 8, 26), Sex.Female, 440.00, TicketClass.Economy),
                        new Passenger("Kateryna", "Milinkina", "Ukrainian", "MS5555", new DateTime(1978, 8, 16), Sex.Female, 440.00, TicketClass.Economy),
                            },
                },
               new Flight(){
                    At = new DateTime(2016, 07, 23, 06, 14, 0),
                    Number=882,
                    CityA = "London/LGW",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="D",
                    Status = FlightStatus.ExpectedAt,
                },
               new Flight(){
                    At = new DateTime(2016, 07, 23, 06, 05, 0),
                    Number=54,
                    CityA = "Odessa",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="A",
                    Status = FlightStatus.Arrived,
                },
                  new Flight(){
                    At = new DateTime(2016, 07, 23, 11, 55, 0),
                    Number=128,
                    CityA = "Paris",
                    CityB =_cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="B",
                    Status = FlightStatus.InFlight,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 12, 00, 0),
                    Number=154,
                    CityA = "Thessaloniki",
                    CityB = _cityHome,
                    AirLine = "Motor Sich Airlines",
                    Terminal ="D",
                    Status = FlightStatus.InFlight,
                },
                      new Flight(){
                    At = new DateTime(2016, 07, 23, 12, 20, 0),
                    Number=232,
                    CityA = "New York",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="D",
                    Status = FlightStatus.ExpectedAt,
                },
                     new Flight(){
                    At = new DateTime(2016, 07, 23, 12, 25, 0),
                    Number=1004,
                    CityA = "Dnipropetrovsk",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="D",
                    Status = FlightStatus.ExpectedAt,
                },
                        new Flight(){
                    At = new DateTime(2016, 07, 23, 12, 30, 0),
                    Number=4452,
                    CityA = "Barselona",
                    CityB = _cityHome,
                    AirLine = "Azur Air Ukrain",
                    Terminal ="C",
                    Status = FlightStatus.Canceled,
                },
                  new Flight(){
                    At = new DateTime(2016, 07, 23, 13, 15, 0),
                    Number=1385,
                    CityA = "Amsterdam",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="D",
                    Status = FlightStatus.Delayed,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 13, 15, 0),
                    Number=9148,
                    CityA = "Frankfurt",
                    CityB = _cityHome,
                    AirLine = "Lufthansa",
                    Terminal ="D",
                    Status = FlightStatus.ExpectedAt,
                },
                    new Flight(){
                    At = new DateTime(2016, 07, 23, 13, 35, 0),
                    Number=882,
                    CityA = "London/LHR",
                    CityB = _cityHome,
                    AirLine = "British Airways",
                    Terminal ="D",
                    Status = FlightStatus.ExpectedAt,
                },
                     new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 15, 0),
                    Number=7171,
                    CityA = "Vienna",
                    CityB = _cityHome,
                    AirLine = "Austrian Airlines",
                    Terminal ="C",
                    Status = FlightStatus.ExpectedAt,
                },
                      new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 35, 0),
                    Number=890,
                    CityA = "Minsk",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="B",
                    Status = FlightStatus.ExpectedAt,
                },
                     new Flight(){
                    At = new DateTime(2016, 07, 23, 17, 00, 0),
                    Number=472,
                    CityA = "Zurich",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="B",
                    Status = FlightStatus.ExpectedAt,
                },
                      new Flight(){
                    At = new DateTime(2016, 07, 23, 17, 15, 0),
                    Number=306,
                    CityA = "Rome",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="C",
                    Status = FlightStatus.ExpectedAt,
                },
                       new Flight(){
                    At = new DateTime(2016, 07, 23, 17, 25, 0),
                    Number=753,
                    CityA = "Warshaw",
                    CityB = _cityHome,
                    AirLine = "LOT-Polish Airlines",
                    Terminal ="C",
                    Status = FlightStatus.ExpectedAt,
                },
                     new Flight(){
                    At = new DateTime(2016, 07, 23, 17, 35, 0),
                    Number=5328,
                    CityA = "Antalya",
                    CityB = _cityHome,
                    AirLine = "Ukraine Iternational Airlines",
                    Terminal ="D",
                    Status = FlightStatus.ExpectedAt,
                },
             new Flight(){
                    At = new DateTime(2016, 07, 23, 07, 00, 0),
                    Number=1653,
                    CityB = "Paris",
                    CityA = _cityHome,
                    AirLine = "Air France",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                     Passengers = new Passenger[] {
                       new Passenger("Mavr", "Mavrody", "Moskovian", "MO6666", new DateTime(1666, 6, 6), Sex.Male, 1000.00, TicketClass.Business),
                        new Passenger("Peter", "Rupoport", "Canadians", "CA3333", new DateTime(1956, 2, 26), Sex.Male, 800.00, TicketClass.Business),
                        new Passenger("Magdalena", "Noyer", "Poles", "PO3214", new DateTime(1999, 8, 9), Sex.Female, 550.00, TicketClass.Economy),
                         new Passenger("Curt", "Cobain", "Americans", "US1111", new DateTime(1975, 3, 15), Sex.Male, 780.00, TicketClass.Business),
                            },
                },

             new Flight(){
                    At = new DateTime(2016, 07, 23, 09, 25, 0),
                    Number=8242,
                    CityB = "Munich",
                    CityA = _cityHome,
                    AirLine = "TAP Portugal",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                     Passengers = new Passenger[] {
                            new Passenger("Kateryna", "Miylinko", "Ukrainian", "MO5555", new DateTime(1988, 8, 16), Sex.Female, 740.00, TicketClass.Business),
                            new Passenger("Ivan", "Sakharchuk", "Ukrainian", "MI4156", new DateTime(1946, 8, 16), Sex.Male, 400.00, TicketClass.Economy),
                            new Passenger("Ivana", "Mikylenko", "Ukrainian", "MU4444", new DateTime(1988, 8, 26), Sex.Female, 440.00, TicketClass.Economy),
                            },
                },
                 new Flight(){
                    At = new DateTime(2016, 07, 23, 07, 40, 0),
                    Number=6555,
                    CityB = "Sofia",
                    CityA = _cityHome,
                    AirLine = "Dniproavia",
                    Terminal ="B",
                    Status = FlightStatus.CheckIn,
                },
                  new Flight(){
                    At = new DateTime(2016, 07, 23, 12, 41, 0),
                    Number=8809,
                    CityB = "Istanbul",
                    CityA = _cityHome,
                    AirLine = "Turkish Airlines inc.",
                    Terminal ="D",
                    Status = FlightStatus.CheckIn,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 00, 0),
                    Number=9208,
                    CityB = "Frankfurt",
                    CityA = _cityHome,
                    AirLine = "Air Canada",
                    Terminal ="D",
                    Status = FlightStatus.GateClosed,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 50, 0),
                    Number=5591,
                    CityB = "Rimini",
                    CityA = "Kyiv",
                    AirLine = "YANAIR",
                    Terminal ="D",
                    Status = FlightStatus.Boarding,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 55, 0),
                    Number=3133,
                    CityB = "Kharkiv",
                    CityA = _cityHome,
                    AirLine = "KLM Roual Dutch Airlines",
                    Terminal ="D",
                    Status = FlightStatus.CheckIn,
                },
                     new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 25, 0),
                    Number=4461,
                    CityB = "Heraklion",
                    CityA = _cityHome,
                    AirLine = "Azur Air Ukraine Airlines",
                    Terminal ="D",
                    Status = FlightStatus.Canceled,
                },
                     new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 45, 0),
                    Number=752,
                    CityB = "Warsaw",
                    CityA = _cityHome,
                    AirLine = "LOT-Polish Airlines",
                    Terminal ="D",
                    Status = FlightStatus.CheckIn,
                },
                      new Flight(){
                    At = new DateTime(2016, 07, 23, 15, 15, 0),
                    Number=1753,
                    CityB = "Paris",
                    CityA = _cityHome,
                    AirLine = "Air France",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 16, 00, 0),
                    Number=3129,
                    CityB = "Tbilici",
                    CityA = _cityHome,
                    AirLine = "KLM Royal Dutch Airlines",
                    Terminal ="D",
                    Status = FlightStatus.Unknown,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 16, 20, 0),
                    Number=2545,
                    CityB = "Munich",
                    CityA = _cityHome,
                    AirLine = "Lufthansa",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 16, 25, 0),
                    Number=5011,
                    CityB = "Sharm el-Sheikh",
                    CityA = _cityHome,
                    AirLine = "YANARIR",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 16, 35, 0),
                    Number=4435,
                    CityB = "Sharm el-Sheikh",
                    CityA = _cityHome,
                    AirLine = "Azur Air Ukraine Airlines",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 16, 45, 0),
                    Number=754,
                    CityB = "Warsaw",
                    CityA =_cityHome,
                    AirLine = "LOT-Polish Airlines",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 55, 0),
                    Number=781,
                    CityB = "Tel-Aviv",
                    CityA =_cityHome,
                    AirLine = "Ukraine International Airlines",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 50, 0),
                    Number=9263,
                    CityB = "Paris",
                    CityA = _cityHome,
                    AirLine = "Ukraine International Airlines",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 15, 15, 0),
                    Number=537,
                    CityB = "Almaty",
                    CityA = _cityHome,
                    AirLine = "Ukraine International Airlines",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 55, 0),
                    Number=7151,
                    CityB = "Barcelona",
                    CityA = _cityHome,
                    AirLine = "Wind Rose Aviation Company",
                    Terminal ="B",
                    Status = FlightStatus.DeparturedAt,
                },
                   new Flight(){
                    At = new DateTime(2016, 07, 23, 14, 55, 0),
                    Number=402,
                    CityB = "Almaty",
                    CityA = _cityHome,
                    AirLine = "Wind Rose Aviation Company",
                    Terminal ="D",
                    Status = FlightStatus.DeparturedAt,
                },
         };
            #endregion flightList
            DateTime dateNow = DateTime.Now;
            for (int i = 0; i < flightList.Count; i++)
                flightList[i].At = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, flightList[i].At.Hour, flightList[i].At.Minute, 00);
        }
        public static IAirportModel Create() => new AirportModel();
        public Flight[] SearchFlightInfo(Jobs doSearchFlighBy, Flight flightTemp)
        {
            SortFlightsPassengersBy("NUMBER");
            List<Flight> retFlight = new List<Flight>(0);
            Flight newFlight = new Flight();
            Passenger newPassenger = new Passenger();
            switch (doSearchFlighBy)
            {
                case Jobs.DoSearchFlighByNumber:
                    retFlight = flightList.FindAll(flight => flight.Number == flightTemp.Number);
                    break;
                case Jobs.DoSearchFlightByCity:
                    retFlight = flightList.FindAll(flight => (flight.CityB == flightTemp.CityB) || (flight.CityA == flightTemp.CityA));
                    break;
                case Jobs.DoSearchFlightByTimeArrival:
                    retFlight = flightList.FindAll(flight => (flight.CityB == flightTemp.CityB && flight.At.Minute == flightTemp.At.Minute && flight.At.Hour == flightTemp.At.Hour));
                    break;
                case Jobs.DoSearchFlightByTimeDeparture:
                    retFlight = flightList.FindAll(flight => (flight.CityA == flightTemp.CityA && flight.At.Minute == flightTemp.At.Minute && flight.At.Hour == flightTemp.At.Hour));
                    break;
                case Jobs.DosearchFlightByTimeLessHour:
                    foreach (Flight flight in flightList)
                    {
                        int hourMinute = flightTemp.At.Hour * 60 + flightTemp.At.Minute;
                        int hourMinuteCompare = flight.At.Hour * 60 + flight.At.Minute;
                        int temp = hourMinute - hourMinuteCompare;
                        if (temp < 0) temp *= -1;
                        if (temp <= 60) retFlight.Add(flight);
                    }
                    break;
                case Jobs.DoSearchPassengerByName:
                    foreach (Flight flight in flightList)
                    {
                        for (int i = 0; i < flight.Passengers.Length; i++)
                            if (flight.Passengers[i] != null && flight.Passengers[i].FirstName == flightTemp.Passengers[0].FirstName)
                            {
                                newPassenger = flight.Passengers[i];
                                for (int j = 1; j < flight.Passengers.Length; j++) flight.Passengers[j] = null;
                                flight.Passengers[0] = newPassenger;
                                retFlight.Add(flight); break;
                            }
                    }
                    break;
                case Jobs.DoSearchPassengerByLastName:
                    foreach (Flight flight in flightList)
                    {
                        for (int i = 0; i < flight.Passengers.Length; i++)
                            if (flight.Passengers[i] != null && flight.Passengers[i].LastName == flightTemp.Passengers[0].LastName)
                            {
                                newPassenger = flight.Passengers[i];
                                for (int j = 1; j < flight.Passengers.Length; j++) flight.Passengers[j] = null;
                                flight.Passengers[0] = newPassenger;
                                retFlight.Add(flight); break;
                            }
                    }
                    break;
                case Jobs.DoSearchPassengerByPassport:
                    foreach (Flight flight in flightList)
                    {
                        for (int i = 0; i < flight.Passengers.Length; i++)
                            if (flight.Passengers[i] != null && flight.Passengers[i].Passport == flightTemp.Passengers[0].Passport)
                            {
                                newPassenger = flight.Passengers[i];
                                for (int j = 1; j < flight.Passengers.Length; j++) flight.Passengers[j] = null;
                                flight.Passengers[0] = newPassenger;
                                retFlight.Add(flight); break;
                            }
                    }
                    break;
                case Jobs.DoSearchFlightByLowCost:
                    foreach (Flight flight in flightList)
                    {
                        for (int i = 0; i < flight.Passengers.Length; i++)
                        {
                            if ((flight.Passengers[i] != null) && (flightTemp.Passengers[0].ticket.price > flight.Passengers[i].ticket.price))
                            {
                                newPassenger = flight.Passengers[i];
                                for (int j = 1; j < flight.Passengers.Length; j++) flight.Passengers[j] = null;
                                flight.Passengers[0] = newPassenger;
                                retFlight.Add(flight); break;
                            }
                        }
                    }
                    break;
            }
            return retFlight.ToArray();
        }
        private void SortFlightsPassengersBy(string sort)
        {
            sort = sort.ToUpper();
            if (sort == "NUMBER") flightList.Sort();
            if (sort == "DATETIME")
            {
                FlightCompareByDateTime compare = new FlightCompareByDateTime();
                flightList.Sort(compare);
            }
            foreach (var flight in flightList)
            {
                Array.Sort(flight.Passengers);
            }
        }
        public Flight[] MakePrintInfo(Jobs taskMode, Flight temp)
        {
            SortFlightsPassengersBy("DateTime");
            return flightList.ToArray();
        }
        public Flight[] EditFlightInfo(Jobs doEditInfo, Flight flightTemp)
        {
            SortFlightsPassengersBy("NUMBER");
            List<Flight> retFlight = new List<Flight>(0);
            Flight newFlight = new Flight();
            Passenger newPassenger = new Passenger();
            switch (doEditInfo)
            {
                case Jobs.DoEditFlightInfo:
                    for (int i = 0; i < flightList.Count; i++)
                        if (flightList[i].Number == flightTemp.Number)
                        {
                            flightList[i] = flightTemp;
                            retFlight.Add(flightList[i]);
                            break;
                        }
                    break;
            }
            return retFlight.ToArray();
        }
        public Flight[] InputNewFlightInfo(Jobs doInputInfo, Flight newFlight)
        {
            switch (doInputInfo)
            {
                case Jobs.DoInputNewFlight:
                    flightList.Add(newFlight);
                    SortFlightsPassengersBy("NUMBER");
                    break;
                case Jobs.DoInputNewPassenger:
                    #region inputnewPassenger
                    for (int i = 0; i < flightList.Count; i++)
                    {
                        if (flightList[i].Number == newFlight.Number)
                        {
                            bool isEmpty = false;
                            for (int j = 0; j < flightList[i].Passengers.Length; j++)
                            {
                                if (flightList[i].Passengers[j] == null)
                                {
                                    flightList[i].Passengers[j] = newFlight.Passengers[0];
                                    isEmpty = true;
                                    break;
                                }
                            }
                            if (!isEmpty)
                            {
                                Array.Resize(ref flightList[i].Passengers, flightList[i].Passengers.Length + 1);
                                flightList[i].Passengers[flightList[i].Passengers.Length - 1] = newFlight.Passengers[0];
                                isEmpty = true;
                            }
                            if (isEmpty)
                                return SearchFlightInfo(Jobs.DoSearchFlighByNumber, newFlight);
                            else
                            {
                                newFlight.Number = 0;
                                return SearchFlightInfo(Jobs.DoSearchFlighByNumber, newFlight);
                            }
                        }
                    }
                    break;
                #endregion
                case Jobs.DoDeletePassenger:
                    for (int j = 0; j < flightList.Count; j++)
                    {
                        if (flightList[j].Number == newFlight.Number)
                        {
                            for (int i = 0; i < flightList[j].Passengers.Length; i++)
                            {
                                if (flightList[j].Passengers[i] != null && flightList[j].Passengers[i].Passport == newFlight.Passengers[0].Passport)
                                {
                                    flightList[j].Passengers[i] = null;
                                    return SearchFlightInfo(Jobs.DoSearchFlighByNumber, newFlight);
                                }
                            }
                        }
                    }
                    newFlight.Number = 0;
                    return SearchFlightInfo(Jobs.DoSearchFlighByNumber, newFlight);
                  //  break;
            }
            return SearchFlightInfo(Jobs.DoSearchFlighByNumber, newFlight);
        }
        public Flight[] DeleteFlightInfo(Jobs deleteFlightInfo, Flight flightTemp)
        {
            flightList.Remove(flightTemp);
            return flightList.ToArray();
        }




    }
}
